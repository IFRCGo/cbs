using doLittle.Runtime.Events;
using doLittle.Events;
using System;
using System.Linq;
using Machine.Specifications;

namespace Domain.Specs
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
            foreach (var @event in _stream)
            {
                if (@event.GetType().Equals(typeof(T)))
                {
                    foundEvent = (T)@event;
                }
            }
            foundEvent.ShouldNotBeNull();
            return new EventValueValidation<T>(foundEvent);


        }

        public EventValueValidation<T> AtBeginning()
        {
            var @event = (T)_stream.FirstOrDefault();
            @event.ShouldNotBeNull();
            @event.ShouldBeOfExactType<T>();
            return new EventValueValidation<T>(@event);
        }

        public EventValueValidation<T> AtEnd()
        {
            var @event = (T)_stream.LastOrDefault();
            @event.ShouldNotBeNull();
            @event.ShouldBeOfExactType<T>();
            return new EventValueValidation<T>(@event);

        }
    }

    public static class EventStreamValidation
    {
        public static EventSequenceValidation<T> ShouldHaveEvent<T>(this IEventSource eventSource) where T : IEvent
        {
            var sequenceValidation = new EventSequenceValidation<T>(eventSource.UncommittedEvents);
            return sequenceValidation;
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