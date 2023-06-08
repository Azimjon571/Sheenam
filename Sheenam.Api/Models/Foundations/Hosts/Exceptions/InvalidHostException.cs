//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================


using Sheenam.Api.Models.Foundations.Guests;
using Xeptions;

namespace Sheenam.Api.Models.Foundations.Hosts.Exceptions
{
    public class InvalidHostException:Xeption
    {
        public InvalidHostException()
            :base(message:"Guest is invalid")
        {}
    }
}
