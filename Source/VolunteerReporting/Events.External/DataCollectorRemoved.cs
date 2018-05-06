using System;
using Dolittle.Events;

namespace Events.External
{
    public class DataCollectorRemoved : IEvent
    {
        public Guid DataCollectorId { get; set; }

    }
}