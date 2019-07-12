using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.Reporting.DataCollectors
{
    [Artifact("5764eae6-fc2e-4c46-a6d7-fd6c978499fc", 1)]
    public class DataCollectorVillageChanged : IEvent
    {
        public string Village { get; }

        public DataCollectorVillageChanged(string village)
        {
            Village = village;
        }
    }
}
