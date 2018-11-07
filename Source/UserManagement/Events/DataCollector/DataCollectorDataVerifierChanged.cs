using System;
using Dolittle.Events;

namespace Events.DataCollector
{
    public class DataCollectorDataVerifierChanged : IEvent
    {
        public Guid DataCollectorId { get; }
        public Guid DataVerifierId { get; }

        public DataCollectorDataVerifierChanged(Guid dataCollectorId, Guid dataVerifierId)
        {
            DataCollectorId = dataCollectorId;
            DataVerifierId = dataVerifierId;
        }
    }
}