//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================


using System;
using Xeptions;

namespace Sheenam.Api.Models.Foundations.Hosts.Exceptions
{
    public class FailedHostStorageException:Xeption
    {
        public FailedHostStorageException(Exception innerException)
            :base(message: "Failed Host storage error occured, contact support",
                 innerException)
        {}
    }
}
