using System;
using Dolittle.Events;

namespace Events.External
{
    public class InvalidReportReceived : IEvent
    {
        public Guid DataCollectorId { get; set; }
        public DateTimeOffset Timestamp { get; set; }

        public InvalidReportReceived(Guid dataCollectorId, DateTimeOffset timestamp)
        {
            DataCollectorId = dataCollectorId;
            Timestamp = timestamp;
        }
    }
}