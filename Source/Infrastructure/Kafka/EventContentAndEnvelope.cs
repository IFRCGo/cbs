using System.Collections.Generic;
using doLittle.Events;

namespace Kafka
{
    public class EventContentAndEnvelope
    {
        public EventContentAndEnvelope(Dictionary<string, object> content, IEventEnvelope envelope)
        {
            Content = content;
            Envelope = envelope;

        }

        public Dictionary<string, object>   Content { get; }
        public IEventEnvelope Envelope { get; }
    }
}