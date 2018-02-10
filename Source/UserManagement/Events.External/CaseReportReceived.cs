using System;
using doLittle.Events;

namespace Events.External
{
    public class CaseReportReceived : IEvent
    {
        public Guid DataCollectorId { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}