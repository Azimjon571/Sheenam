﻿//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================


using System.Threading.Tasks;
using Sheenam.Api.Models.Foundations.Guests;

namespace Sheenam.Api.Services.Foundations.Guests
{
    public interface IGuestService
    {
        ValueTask<Guest> AddGuestAsync(Guest guest);
    }
}
