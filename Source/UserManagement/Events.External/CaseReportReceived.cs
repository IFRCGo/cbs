using System;
using Dolittle.Events;

namespace Events.External
{
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