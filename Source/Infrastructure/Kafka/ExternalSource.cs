using doLittle.Events;

namespace Kafka
{
    public class ExternalSource : EventSource
    {
        public ExternalSource(EventSourceId id) : base(id) { }

    }
}