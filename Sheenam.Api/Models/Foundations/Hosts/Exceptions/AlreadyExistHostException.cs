﻿//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================


using System;
using Xeptions;

namespace Sheenam.Api.Models.Foundations.Hosts.Exceptions
{
    public class AlreadyExistHostException:Xeption
    {
        public AlreadyExistHostException(Exception innerException)
            : base(message: "Host already exists", innerException)
        {}
    }
}
