using Microsoft.EntityFrameworkCore;
using Sheenam.Api.Models.Foundations.Hosts;

namespace Sheenam.Api.Brokers.Strorages
{
    public partial class StorageBroker
    {
        public DbSet<HoSt> HoSts { get; set; }
    }
}
