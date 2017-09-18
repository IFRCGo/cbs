using Machine.Specifications;

namespace Events.Specs.for_EventPublisher.given
{
    public class an_event_publisher
    {
        protected static EventPublisher publisher;

        Establish context = () => publisher = new EventPublisher();
    }
}