//=============
//
//
//
//=============


using Microsoft.EntityFrameworkCore;
using Sheenam.Api.Models.Foundations.Guests;

namespace Sheenam.Api.Brokers.Strorages
{
    public partial class StorageBroker
    {
        public DbSet<Guest> Guests { get; set; }
    }
}
