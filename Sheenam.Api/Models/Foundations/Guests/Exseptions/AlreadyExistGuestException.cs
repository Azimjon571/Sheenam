//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================


using System;
using Xeptions;

namespace Sheenam.Api.Models.Foundations.Guests.Exseptions
{
    public class AlreadyExistGuestException : Xeption
    {
        public AlreadyExistGuestException(Exception innerException)
            : base(message: "Guest already exists", innerException)
        { }
    }
}
