using System;
using System.Collections.Generic;
using System.Text;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.External
{
    [Artifact("635304c5-c8aa-4b09-a968-408d2d81a08b")]
    public class NotificationReceived : IEvent
    {
        public NotificationReceived(Guid id, string message, string originNumber, DateTimeOffset sent)
        {
            this.Id = id;
            this.Message = message;
            this.OriginNumber = originNumber;
            this.Sent = sent;
        }
        public Guid Id { get; }
        public string Message { get; }
        public string OriginNumber { get; }
        public DateTimeOffset Sent { get; }
    }
}
