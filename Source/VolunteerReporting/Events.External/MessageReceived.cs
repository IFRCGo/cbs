using System;
using System.Collections.Generic;
using System.Text;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.External
{
    [Artifact("635304c5-c8aa-4b09-a968-408d2d81a08b")]
    class MessageReceived : IEvent
    {
        public MessageReceived(Guid id, string message, string number, DateTimeOffset timestamp)
        {
            this.Id = id;
            this.Message = message;
            this.Number = number;
            this.Timestamp = timestamp;
        }
        public Guid Id { get; }
        public string Message { get; }
        public string Number { get; }
        public DateTimeOffset Timestamp { get; }
    }
}
