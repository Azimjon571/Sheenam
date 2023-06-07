//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use Find Comfort and Peace
//=================================================

using Moq;
using Sheenam.Api.Brokers.Loggings;
using Sheenam.Api.Brokers.Strorages;
using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Models.Foundations.Hosts;
using Sheenam.Api.Services.Foundations.Hosts;
using Tynamix.ObjectFiller;

namespace Sheenam.Api.Test.Unit.Services.Foundations.Hosts
{
    public partial class HostServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IHostService hostService;

        public HostServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.hostService = new HostService(
                storageBroker: this.storageBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private static HoSt CreateRandomHost() =>
            CreateHostFiller(date: GetRandomDateTimeOffset()).Create();

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static Filler<HoSt> CreateHostFiller(DateTimeOffset date)
        {
            var filler = new Filler<HoSt>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(date);

            return filler;
        }
    }
}
