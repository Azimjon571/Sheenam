//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================

using FluentAssertions;
using Microsoft.Extensions.Hosting;
using System;
using Moq;
using Sheenam.Api.Models.Foundations.Hosts;
using Sheenam.Api.Models.Foundations.Hosts.Exceptions;
using Xunit;

namespace Sheenam.Api.Test.Unit.Services.Foundations.Hosts
{
    public partial class HostServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfHostIsNullAndLogItAsync()
        {
            //given
            HoSt nulHost = null;

            var nullHostException = new NullHostException();

            var expectedHostValidationException =
                new HostValidationException(nullHostException);

            //when
            ValueTask<HoSt> addHostTaks =
                this.hostService.AddHostAsync(nulHost);

            //then
            await Assert.ThrowsAsync<HostValidationException>(() =>
                addHostTaks.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedHostValidationException))),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertHostAsync(It.IsAny<HoSt>()),
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnAddIfHostIsInvalidAndLogItAsync(
           string invalidString)
        {
            // given
            var invalidHost = new HoSt
            {
                FistName = invalidString
            };

            var invalidHostException = new InvalidHostException();

            invalidHostException.AddData(
                key: nameof(HoSt.Id),
                values: "Id is required");

            invalidHostException.AddData(
                key: nameof(HoSt.FistName),
                values: "Text is required");

            invalidHostException.AddData(
                key: nameof(HoSt.LastName),
                values: "Text is required");

            invalidHostException.AddData(
                key: nameof(HoSt.DateOfBirth),
                values: "Value is required");

            invalidHostException.AddData(
                key: nameof(HoSt.Email),
                values: "Text is required");

            invalidHostException.AddData(
                key: nameof(HoSt.PhoneNumber),
                values: "Text is required");


            var expectedHostValidationException =
                new HostValidationException(invalidHostException);

            // when
            ValueTask<HoSt> addHostTask = this.hostService.AddHostAsync(invalidHost);

            HostValidationException actualHostValidationException =
                await Assert.ThrowsAsync<HostValidationException>(addHostTask.AsTask);

            // then
            actualHostValidationException.Should().BeEquivalentTo(expectedHostValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedHostValidationException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertHostAsync(It.IsAny<HoSt>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfGenderIsInvalidAndLogItAsync()
        {
            //given
            HoSt randomHost = CreateRandomHost();
            HoSt invalidHost = randomHost;
            invalidHost.Gender = GetInvalidEnum<GenderType>();
            var invalidHostException = new InvalidHostException();


            invalidHostException.AddData(
                key: nameof(HoSt.Gender),
                values: "Value is invalid");
            
            var expectedHostValidationException = 
                new HostValidationException(invalidHostException);

            //when

            ValueTask<HoSt> addHostTask =
                this.hostService.AddHostAsync(invalidHost);

            
            HostValidationException actualHostValidationException=
                await Assert.ThrowsAsync<HostValidationException>(() =>
                    addHostTask.AsTask());

            //then
            actualHostValidationException.Should().BeEquivalentTo(expectedHostValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedHostValidationException))),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertHostAsync(It.IsAny<HoSt>()),
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
