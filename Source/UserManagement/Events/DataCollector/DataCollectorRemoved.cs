using Dolittle.Events;
using System;

namespace Events.DataCollector
{
    public class DataCollectorRemoved : IEvent
    {
        public Guid DataCollectorId { get; set; }

        public DataCollectorRemoved(Guid dataCollectorId)
        {
            DataCollectorId = dataCollectorId;
        }
    }
}
