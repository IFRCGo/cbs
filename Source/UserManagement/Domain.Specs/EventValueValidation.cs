using System;
using Dolittle.Events;
using Machine.Specifications;

namespace Domain.Specs
{
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