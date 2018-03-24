using System;
using doLittle.Events;

namespace Events.External
{
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