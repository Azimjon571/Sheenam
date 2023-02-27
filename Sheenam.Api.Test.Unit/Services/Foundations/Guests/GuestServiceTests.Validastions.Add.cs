﻿//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================

using Moq;
using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Models.Foundations.Guests.Exseptions;
namespace Sheenam.Api.Test.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExseptionOnAddIfGuestIsNullAddLogItAsync()
        {
            //given
            Guest nullGuest = null;

            var nullGuestException = new NullGuestException();

            var exceptedGuestValidationException =
                new GuestValidationException(nullGuestException);

            //when

            ValueTask<Guest> addGuestTask =
                this.guestService.AddGuestAsync(nullGuest);
            //then
            await Assert.ThrowsAsync<GuestValidationException>(() =>
            addGuestTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(exceptedGuestValidationException))),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertGuestAsync(It.IsAny<Guest>()),
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExseptionOnAddIfGuestIsInvalidAndLogItAsync(
            string invalidText)
        {
            //given
            var invalidGuest = new Guest
            {
                FirstName = invalidText
            };  

            var invalidGuestException = new InvalidGuestException();

            invalidGuestException.AddData(
                key: nameof(Guest.Id),
                values: "Id is required");

            invalidGuestException.AddData(
                key: nameof(Guest.FirstName),
                values: "Text is required");

            invalidGuestException.AddData(
                key: nameof(Guest.LastName),
                values: "Text is required");

            invalidGuestException.AddData(
                key: nameof(Guest.DateOfBirth),
                values: "Date is required");

            invalidGuestException.AddData(
                key: nameof(Guest.Email),
                values: "Text is required");

            invalidGuestException.AddData(
                key: nameof(Guest.Address),
                values: "Text is required");

            var expectedGuestValidationException =
                new GuestValidationException(invalidGuestException);

            //when
            ValueTask<Guest> addGuestTask =
                this.guestService.AddGuestAsync(invalidGuest);

            //then
            await Assert.ThrowsAsync<GuestValidationException>(() =>
                addGuestTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedGuestValidationException))),
                        Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertGuestAsync(It.IsAny<Guest>()),
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfGenderIsInvalidAndLogItAsync()
        {
            //given
            Guest randomGuest = CreateRandomGuest();
            Guest invalidGuest = randomGuest;
            invalidGuest.Gender = GetInvalidEnum<GenderType>();
            var invalidGuestException = new InvalidGuestException();

            invalidGuestException.AddData(
                key: nameof(Guest.Gender),
                values: "Value is invalid");

            var expectedGuestValidationException =
                new GuestValidationException(invalidGuestException);

            //when

            ValueTask<Guest> addGuestTask =
                this.guestService.AddGuestAsync(invalidGuest);

            //then
            await Assert.ThrowsAsync<GuestValidationException>(()=>
                addGuestTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedGuestValidationException))),
                    Times.Once);

            this.storageBrokerMock.Verify(broker=>
                broker.InsertGuestAsync(It.IsAny<Guest>()),
                Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
