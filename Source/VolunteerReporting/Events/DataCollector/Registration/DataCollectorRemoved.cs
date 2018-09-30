using Dolittle.Events;
using System;

namespace Events.DataCollectors.Registration
{
    public class DataCollectorRemoved : IEvent
    {
        public Guid DataCollectorId { get;}

        public DataCollectorRemoved(Guid dataCollectorId)
        {
            DataCollectorId = dataCollectorId;
        }
    }
}
