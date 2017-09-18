using Machine.Specifications;

namespace Events.Specs.for_EventPublisher
{
    public class when_publishing_single_event : given.an_event_publisher
    {   
        static EventOrigin origin;
        static SimpleEvent  event_to_publish;

        Establish context = () => 
        {
            event_to_publish = new SimpleEvent();
        };

        Because of = () => publisher.Publish(origin, event_to_publish);

        It should_do_stuff = () => true.ShouldBeTrue();
        
    }
}