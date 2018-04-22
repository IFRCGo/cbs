using System;
using Dolittle.Events;

namespace Events.External
{
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