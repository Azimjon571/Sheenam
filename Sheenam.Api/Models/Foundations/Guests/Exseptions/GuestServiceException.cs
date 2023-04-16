//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================


using Xeptions;

namespace Sheenam.Api.Models.Foundations.Guests.Exseptions
{
    public class GuestServiceException : Xeption
    {
        public GuestServiceException(Xeption innerException)
            : base(message: "Guest service error occurred, contact support",
                 innerException)
        { }
    }
}
