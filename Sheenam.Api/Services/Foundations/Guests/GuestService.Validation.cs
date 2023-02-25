﻿//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================


using System;
using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Models.Foundations.Guests.Exseptions;

namespace Sheenam.Api.Services.Foundations.Guests
{
    public partial class GuestService
    {
        private void ValidateGuestOnAdd(Guest guest)
        {
            ValidateGuestNull(guest);

            Validate(
                (Rule:IsInvalid(guest.Id),Parameter:nameof(Guest.Id)),
                (Rule:IsInvalid(guest.FirstName),Parameter:nameof(Guest.FirstName)),
                (Rule:IsInvalid(guest.LastName),Parameter:nameof(Guest.LastName)),
                (Rule:IsInvalid(guest.DateOfBirth),Parameter:nameof(Guest.DateOfBirth)),
                (Rule:IsInvalid(guest.Email),Parameter:nameof(Guest.Email)),
                (Rule:IsInvalid(guest.Address),Parameter:nameof(Guest.Address)));

        }
        private void ValidateGuestNull(Guest guest)
        {
            if (guest is null)
            {
                throw new NullGuestException();
            }

        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message="Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message="Text is required"
        };

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date==default,
            Message = "Date is required"
        };
        private static void Validate(params (dynamic Rule,string Parameter)[] validations)
        {
            var invalidGuestException=new InvalidGuestException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidGuestException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidGuestException.ThrowIfContainsErrors();

        }
    }
}