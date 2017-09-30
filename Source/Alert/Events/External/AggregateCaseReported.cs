using System;
using Infrastructure.Events;

namespace Events.External
{
    public class AggregateCaseReported : IEvent
    {
        public Guid Id { get; set; }
    }
}
