using Dolittle.Runtime.Events;
using Dolittle.Events;
using System;
using System.Linq;
using Machine.Specifications;
using Dolittle.Runtime.Events.Store;

namespace Machine.Specifications
{
    public class EventSequenceValidation<T> where T : IEvent
    {
        readonly UncommittedEventStream _stream;

        public EventSequenceValidation(UncommittedEventStream stream)
        {
            _stream = stream;
        }

        public EventValueValidation<T> InStream()
        {
            var foundEvent = default(T);
            foreach (var @event in _stream.Events)
            {
                if (@event.GetType().Equals(typeof(T)))
                {
                    // foundEvent = (T)@event;
                    // foundEvent = (T)Events.
                }
            }
            foundEvent.ShouldNotBeNull();
            return new EventValueValidation<T>(foundEvent);
        }

        public EventValueValidation<T> AtBeginning()
        {
            // var @event = (T)_stream.FirstOrDefault();
            // @event.ShouldNotBeNull();
            // @event.ShouldBeOfExactType<T>();
            return new EventValueValidation<T>(default(T));
        }

        public EventValueValidation<T> AtEnd()
        {
            // var @event = (T)_stream.LastOrDefault();
            // @event.ShouldNotBeNull();
            // @event.ShouldBeOfExactType<T>();
            return new EventValueValidation<T>(default(T));
        }

        public void Instances(int expected)
        {
            // _stream.OfType<T>().Count().ShouldEqual(expected);
        }
    }

    public static class EventStreamValidation
    {
        public static EventSequenceValidation<T> ShouldHaveEvent<T>(this IEventSource eventSource) where T : IEvent
        {
            // var sequenceValidation = new EventSequenceValidation<T>(eventSource.UncommittedEvents);
            var sequenceValidation = new EventSequenceValidation<T>(null);
            return sequenceValidation;
        }

        public static void ShouldNotHaveEvent<T>(this IEventSource eventSource) where T : IEvent
        {
            eventSource.UncommittedEvents.OfType<T>().Any().ShouldBeFalse();
        }
    } 

    public class EventValueValidation<T> where T : IEvent
    {
        readonly T _event;

        public EventValueValidation(T @event)
        {
            _event = @event;
        }

        public void WithValues(params Func<T, bool>[] expectedValues)
        {
            foreach (var expectedValue in expectedValues)
            {
                expectedValue(_event).ShouldBeTrue();
            }
        }

        public void Where(params Action<T>[] validators)
        {
            foreach (var validator in validators)
            {
                validator(_event);
            }
        }
    } 
}