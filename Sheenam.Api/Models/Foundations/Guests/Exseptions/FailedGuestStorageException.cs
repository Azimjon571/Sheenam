﻿//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================


using System;
using Xeptions;

namespace Sheenam.Api.Models.Foundations.Guests.Exseptions
{
    public class FailedGuestStorageException : Xeption
    {
        public FailedGuestStorageException(Exception innerException)
            : base(message: "Failed guest storage error occured, contact support",
                 innerException)
        { }
    }
}
