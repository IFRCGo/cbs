using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.External
{
    [Artifact("e6d941c9-f9eb-4123-828b-7f814386c154")]
    public class CaseReportReceived : IEvent
    {
        public Guid DataCollectorId { get; set; }
        public DateTimeOffset Timestamp { get; set; }

        public CaseReportReceived(Guid dataCollectorId, DateTimeOffset timestamp)
        {
            DataCollectorId = dataCollectorId;
            Timestamp = timestamp;
        }
    }
}