//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================


using System;
using Azure.Messaging;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Hosting;
using Sheenam.Api.Models.Foundations.Hosts;
using Sheenam.Api.Models.Foundations.Hosts.Exceptions;

namespace Sheenam.Api.Services.Foundations.Hosts
{
    public partial class HostService
    {
        private void ValidateHostOnAdd(HoSt host)
        {
            ValidateHostNotNull(host);

            Validate(
                (Rule: IsInvalid(host.Id), Parameter: nameof(HoSt.Id)),
                (Rule: IsInvalid(host.FistName), Parameter: nameof(HoSt.FistName)),
                (Rule: IsInvalid(host.LastName), Parameter: nameof(HoSt.LastName)),
                (Rule: IsInvalid(host.DateOfBirth), Parameter: nameof(HoSt.DateOfBirth)),
                (Rule: IsInvalid(host.Email), Parameter: nameof(HoSt.Email)),
                (Rule: IsInvalid(host.PhoneNumber), Parameter: nameof(HoSt.PhoneNumber)),
                (Rule: IsInvalid(host.Gender), Parameter: nameof(HoSt.Gender)));
        }
        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == default,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Value is required"
        };

        private static dynamic IsInvalid(GenderType gender) => new
        {
            Condition = Enum.IsDefined(typeof(GenderType), gender) is false,
            Message = "Value is invalid"
        };
        private void ValidateHostNotNull(HoSt hoSt)
        {
            if (hoSt is null)
            {
                throw new NullHostException();
            }
        }
        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidHostException = new InvalidHostException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidHostException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidHostException.ThrowIfContainsErrors();
        }
    }
}
