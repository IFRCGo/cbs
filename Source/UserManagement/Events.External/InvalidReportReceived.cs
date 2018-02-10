using System;
using doLittle.Events;

namespace Events.External
{
    public class InvalidReportReceived : IEvent
    {
        public Guid DataCollectorId { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}