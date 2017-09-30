using System;
using System.Linq;
using doLittle.Types;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Infrastructure.Events.Web
{
    [Route("/api/events")]
    public class EventsController
    {
        readonly IEventProcessors _eventProcessors;
        readonly ITypeFinder _typeFinder;

        public EventsController(IEventProcessors eventProcessors, ITypeFinder typeFinder)
        {
            _eventProcessors = eventProcessors;
            _typeFinder = typeFinder;
        }

        [HttpPost]
        public void Post([FromBody]Event @event)
        {
            var eventType = _typeFinder.All.Where(type => type.Name == @event.Name).SingleOrDefault();
            if( eventType == null ) throw new ArgumentException("Cannot resolve Event Type from Name - please check the name again");

            var serialized = JsonConvert.SerializeObject(@event.Content);
            var typed = JsonConvert.DeserializeObject(serialized,eventType) as IEvent;

            var envelope = new EventEnvelope(EventSequenceNumber.Zero, EventCorrelationId.NotSet, EventOrigin.Unknown, typed);
            _eventProcessors.Process(envelope);
        }
    }
}