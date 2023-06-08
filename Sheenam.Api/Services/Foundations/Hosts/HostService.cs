//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================


using System.Threading.Tasks;
using Sheenam.Api.Brokers.Loggings;
using Sheenam.Api.Brokers.Strorages;
using Sheenam.Api.Models.Foundations.Hosts;
using Sheenam.Api.Models.Foundations.Hosts.Exceptions;

namespace Sheenam.Api.Services.Foundations.Hosts
{
    public partial class HostService : IHostService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public HostService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<HoSt> AddHostAsync(HoSt hoSt) =>
        TryCatch(async() =>
        {
            ValidateHostOnAdd(hoSt);

            return await this.storageBroker.InsertHostAsync(hoSt);
        });
    }
}
