//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================


using Xeptions;

namespace Sheenam.Api.Models.Foundations.Hosts.Exceptions
{
    public class HostValidationException: Xeption
    {
        public HostValidationException(Xeption innerException)
            :base(message: "Host validation error occurred, fix the error and try again",
                  innerException)
        {}
    }
}
