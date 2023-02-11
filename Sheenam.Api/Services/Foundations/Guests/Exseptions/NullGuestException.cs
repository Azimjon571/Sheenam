//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================


using System;
using Xeptions;

namespace Sheenam.Api.Services.Foundations.Guests.Exseptions
{
    public class NullGuestException:Xeption
    {
        public NullGuestException()
            : base(message:"Guest is null") 
        {}
        

    }
}
