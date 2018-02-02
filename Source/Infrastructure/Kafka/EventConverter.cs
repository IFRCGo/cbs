using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using doLittle.Dynamic;
using doLittle.Events;

namespace Kafka
{
    public class EventConverter : IEventConverter
    {
        public IEnumerable<EventContentAndEnvelope> Convert(IEnumerable<EventAndEnvelope> eventAndEnvelopes)
        {
            var converted = eventAndEnvelopes.Select(e => new EventContentAndEnvelope(AsDictionary(e.Event), e.Envelope));
            return converted;
        }

        public IEnumerable<IEvent> Convert(IEnumerable<EventContentAndEnvelope> eventContentAndEnvelopes)
        {
            throw new System.NotImplementedException();

            /*
            On the Event Envelope sits an identifier for the Event.

            Find the first event type that matches the name (naive approach) in the ExternalEvents namespace (by convention)

            Deserialize from the Dictionary to that event 
            (Default constructor support - EventSourceId)

            return array of these events
             */
        }

        Dictionary<string,object> AsDictionary(IEvent @event)
        {
            var dictionary = new Dictionary<string,object>();

            foreach (var property in @event.GetType().GetTypeInfo().GetProperties())
                dictionary[property.Name] = property.GetValue(@event, null);

            return dictionary;
        }        
    }
}