//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================


using System;
using Xeptions;

namespace Sheenam.Api.Models.Foundations.Hosts.Exceptions
{
    public class FailedHostServiceException:Xeption
    {
        public FailedHostServiceException(Exception innerException)
            :base(message:"Failed Host service error occured, contact support", innerException)
        {}
    }
}
