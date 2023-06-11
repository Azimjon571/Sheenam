//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================


using Xeptions;

namespace Sheenam.Api.Models.Foundations.Guests.Exseptions
{
    public class GuestValidationException : Xeption
    {
        public GuestValidationException(Xeption innerException)
            : base(message: "Guest validation error occurred, fix the error and try again",
                  innerException)
        { }
    }
}
