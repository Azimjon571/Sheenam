//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================


using Xeptions;

namespace Sheenam.Api.Models.Foundations.Hosts.Exceptions
{
    public class NullHostException:Xeption
    {
        public NullHostException()
            :base(message:"Host is null")
        {}
    }
}
