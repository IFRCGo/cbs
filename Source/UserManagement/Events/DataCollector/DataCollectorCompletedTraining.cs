using System;
using Dolittle.Events;

namespace Events.DataCollector
{
    public class DataCollectorCompletedTraining : IEvent
    {
        public Guid DataCollectorId { get; }

        public DataCollectorCompletedTraining(Guid dataCollectorId)
        {
            DataCollectorId = dataCollectorId;
        }
    }
}
