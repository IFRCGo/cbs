using doLittle.Runtime.Events;

namespace Infrastructure.Events.Web
{
    public class EventsControllerEventSource : EventSource
    {
        public EventsControllerEventSource(EventSourceId id) : base(id)
        {
        }
    }
}