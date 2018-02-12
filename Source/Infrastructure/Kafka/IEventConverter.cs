using System.Collections.Generic;
using doLittle.Events;
using doLittle.Runtime.Events;

namespace Kafka
{
    public interface IEventConverter
    {
        IEnumerable<EventContentAndEnvelope> Convert(IEnumerable<EventAndEnvelope> eventAndEnvelopes);
        IEnumerable<IEvent> Convert(IEnumerable<EventContentAndEnvelope> eventContentAndEnvelopes);
    }
}