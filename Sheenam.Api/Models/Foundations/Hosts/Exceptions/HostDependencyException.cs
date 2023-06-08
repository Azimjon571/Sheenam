//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================


using System;
using Xeptions;

namespace Sheenam.Api.Models.Foundations.Hosts.Exceptions
{
    public class HostDependencyException:Xeption
    {
        public HostDependencyException(Exception innerException)
            : base(message: "Host Dependency error occured, contact support",
                  innerException)
        { }
    }
}
