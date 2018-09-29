using System;
using Dolittle.Events;

namespace Events.DataCollector
{
    public class DataCollectorBeganTraining : IEvent
    {
        public Guid DataCollectorId { get;  }

        public DataCollectorBeganTraining(Guid dataCollectorId)
        {
            DataCollectorId = dataCollectorId;
        }
    }
}
