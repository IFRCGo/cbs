using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.External
{
    
    [Artifact("256396b8-bb23-4ef4-97ab-973575cb4ba6")]
    public class InvalidReportReceived : IEvent
    {
        public Guid DataCollectorId { get; }
        public DateTimeOffset Timestamp { get; }

        public InvalidReportReceived(Guid dataCollectorId, DateTimeOffset timestamp)
        {
            DataCollectorId = dataCollectorId;
            Timestamp = timestamp;
        }
    }
}