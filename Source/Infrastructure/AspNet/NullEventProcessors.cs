using System.Collections.Generic;
using doLittle.Events;
using doLittle.Runtime.Events;
using doLittle.Runtime.Events.Processing;

namespace Infrastructure.AspNet
{
    public class NullEventProcessors : IEventProcessors
    {
        public IEnumerable<IEventProcessor> All => new IEventProcessor[0];

        public IEventProcessingResults Process(IEventEnvelope envelope, IEvent @event)
        {
            var results = new EventProcessingResults(new IEventProcessingResult[0]);
            return results;
        }
    }
}