using System;
using System.Collections.Generic;
using System.Text;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.External
{
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
