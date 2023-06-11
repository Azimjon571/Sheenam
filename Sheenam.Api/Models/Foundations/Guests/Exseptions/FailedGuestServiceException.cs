﻿//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================


using System;
using Xeptions;

namespace Sheenam.Api.Models.Foundations.Guests.Exseptions
{
    public class FailedGuestServiceException : Xeption
    {
        public FailedGuestServiceException(Exception innerException)
            : base(message: "Failed guest service error occured, contact support", innerException)
        { }
    }
}
