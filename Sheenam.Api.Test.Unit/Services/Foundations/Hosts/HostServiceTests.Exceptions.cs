//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================

using EFxceptions.Models.Exceptions;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;
using Sheenam.Api.Models.Foundations.Hosts;
using Sheenam.Api.Models.Foundations.Hosts.Exceptions;
using Xunit;

namespace Sheenam.Api.Test.Unit.Services.Foundations.Hosts
{
    public partial class HostServiceTests
    {
        [Fact]
        public async Task ShouldThrowHostCriticalDependencyExceptionOnAddIfSqlErrorOccursAndLogItAsync()
        {
            // given
            HoSt someHost = CreateRandomHost();
            SqlException sqlException = CreateSqlException();
            var failedHostStorageException = new FailedHostStorageException(sqlException);

            var expectedHostDependencyException =
                new HostDependencyException(failedHostStorageException);

           
            // when
            ValueTask<HoSt> addHostTask = this.hostService.AddHostAsync(someHost);

            HostDependencyException actualHostDependencyException =
                await Assert.ThrowsAsync<HostDependencyException>(()=>
                    addHostTask.AsTask());

            // then
            actualHostDependencyException.Should().BeEquivalentTo(expectedHostDependencyException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(
                    expectedHostDependencyException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertHostAsync(It.IsAny<HoSt>()), Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowHostDependencyValidationOnAddIfDuplicateKeyErrorOccursAndLogItAsync()
        {
            //given
            HoSt someHost = CreateRandomHost();
            string someMessage = CreateRandomString();

            var duplicateKeyException =
                new DuplicateKeyException(someMessage);

            var alreadyExistHostException =
                new AlreadyExistHostException(duplicateKeyException);

            var expectedHostDependencyValidationException =
                new HostDependencyValidationException(alreadyExistHostException);

            this.storageBrokerMock.Setup(broker =>
            broker.InsertHostAsync(someHost)).
                ThrowsAsync(duplicateKeyException);

            //when
            ValueTask<HoSt> addHostTask =
                this.hostService.AddHostAsync(someHost);

            //then
            await Assert.ThrowsAsync<HostDependencyValidationException>(() =>
                addHostTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
                broker.InsertHostAsync(someHost),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedHostDependencyValidationException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
