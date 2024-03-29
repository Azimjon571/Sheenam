﻿//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================


using System;
using Xeptions;

namespace Sheenam.Api.Models.Foundations.Guests.Exseptions
{
    public class GuestDependencyException : Xeption
    {
        public GuestDependencyException(Exception innerException)
            : base(message: "Guest Dependency error occured, contact support",
                  innerException)
        { }
    }
}
