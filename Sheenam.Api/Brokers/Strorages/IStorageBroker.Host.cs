//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================


using System.Threading.Tasks;
using Sheenam.Api.Models.Foundations.Hosts;

namespace Sheenam.Api.Brokers.Strorages
{
    public partial interface IStorageBroker
    {
        ValueTask<HoSt> InsertHostAsync(HoSt hoSt);
    }
}
