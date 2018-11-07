using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.VolunteerReporting.CaseReports
{
    [Artifact("e6d941c9-f9eb-4123-828b-7f814386c154")]
    public class CaseReportReceived : IEvent
    {
        public Guid DataCollectorId { get; }
        public DateTimeOffset Timestamp { get; }

        public CaseReportReceived(Guid dataCollectorId, DateTimeOffset timestamp)
        {
            DataCollectorId = dataCollectorId;
            Timestamp = timestamp;
        }
    }
}