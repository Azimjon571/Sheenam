//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================


using Xeptions;

namespace Sheenam.Api.Models.Foundations.Guests.Exseptions
{
    public class GuestDependencyValidationException : Xeption
    {
        public GuestDependencyValidationException(Xeption innerException)
            : base(message: "Guest dependency validation error occured, fix the error and try again", innerException)
        { }
    }
}
