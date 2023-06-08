//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================

using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Sheenam.Api.Models.Foundations.Hosts;
using Xunit;

namespace Sheenam.Api.Test.Unit.Services.Foundations.Hosts
{
    public partial class HostServiceTests
    {
        [Fact]
        public async Task ShouldAddHostAsync()
        {
            //given
            HoSt randomHost = CreateRandomHost();
            HoSt inputHost = randomHost;
            HoSt storageHost = inputHost;
            HoSt expectedHost = storageHost.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertHostAsync(inputHost))
                    .ReturnsAsync(storageHost);

            //when
            HoSt actualHost=
                await this.hostService.AddHostAsync(inputHost);

            //then
            actualHost.Should().BeEquivalentTo(expectedHost);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertHostAsync(inputHost),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
