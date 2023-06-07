//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================

using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Sheenam.Api.Models.Foundations.Guests;
using Xunit;

namespace Sheenam.Api.Test.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {

        [Fact]
        public async Task ShouldAddGuestAsync()
        {
            //given
            Guest randomGuest = CreateRandomGuest();
            Guest inputGuest = randomGuest;
            Guest storageGuest = inputGuest;
            Guest expectedGueast = storageGuest.DeepClone();

            this.storageBrokerMock.Setup(broker =>
            broker.InsertGuestAsync(inputGuest))
                .ReturnsAsync(storageGuest);
            //when

            Guest actualGuest =
                await this.guestService.AddGuestAsync(inputGuest);

            //then

            actualGuest.Should().BeEquivalentTo(expectedGueast);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertGuestAsync(inputGuest),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
