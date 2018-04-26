using Dolittle.Events;
using System;

namespace Events.DataCollector
{
    public class DataCollectorRemoved : IEvent
    {
        public Guid DataCollectorId { get; }

        public DataCollectorRemoved(Guid dataCollectorId)
        {
            DataCollectorId = dataCollectorId;
        }
    }
}
