using System.Collections.Generic;
using Infrastructure.Application;
using Infrastructure.Events;
using System;
using System.Linq;

namespace Read.Tests.Mockups
{
    public class MockupEventEmitter : Infrastructure.Events.IEventEmitter
    {
        private Queue<Tuple<Feature, IEvent>> _events = new Queue<Tuple<Feature, IEvent>>();

        public void Emit(Feature feature, IEvent @event)
        {
            _events.Enqueue(new Tuple<Feature, IEvent>(feature, @event));
        }

        public void Emit(Feature feature, IEnumerable<IEvent> events)
        {
            foreach (var @event in events)
                Emit(feature, @event);
        }

        public (Feature feature, IEvent @event) PopFirst()
        {
            var item = _events.Dequeue();
            return (item.Item1, item.Item2);
        }
    }
}
