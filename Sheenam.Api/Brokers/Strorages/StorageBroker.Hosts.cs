<<<<<<< Updated upstream
﻿using System.Threading.Tasks;
=======
﻿//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================


using System.Threading.Tasks;
>>>>>>> Stashed changes
using Microsoft.EntityFrameworkCore;
using Sheenam.Api.Models.Foundations.Hosts;

namespace Sheenam.Api.Brokers.Strorages
{
    public partial class StorageBroker
    {
        public DbSet<HoSt> HoSts { get; set; }

        public async ValueTask<HoSt> InsertHostAsync(HoSt hoSt) =>
            await InsertAsync(hoSt);
    }
}
