using System;
using System.Collections.Generic;
using System.Text;
using Events;
using Events.External;
using Infrastructure.Events;
using Newtonsoft.Json;

namespace Read
{
    public class OutgoingEventProcessor : Infrastructure.Events.IEventProcessor
    {
        private readonly IOutgoingEvents _outgoingEvents;

        public OutgoingEventProcessor(IOutgoingEvents outgoingEvents)
        {
            _outgoingEvents = outgoingEvents;
        }

        public void Process(AlertClosed @event)
        {
            SaveEvent(nameof(AlertRaised), @event);
        }

        public void Process(AlertEscalated @event)
        {
            SaveEvent(nameof(AlertEscalated), @event);
        }

        public void Process(AlertRaised @event)
        {
            SaveEvent(nameof(AlertRaised), @event);
        }

        public void Process(SmsSentEvent @event)
        {
            SaveEvent(nameof(SmsSentEvent), @event);
        }

        private void SaveEvent(string eventName, IEvent eventPayload)
        {
            string payload = JsonConvert.SerializeObject(eventPayload);
            _outgoingEvents.Save(new OutgoingEvent() { EventName = eventName, Payload = payload});
        }
    }
}
