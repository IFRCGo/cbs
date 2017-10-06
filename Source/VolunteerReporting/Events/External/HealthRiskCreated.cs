using Infrastructure.Events;
using System;

namespace Events.External
{
    public class HealthRiskCreated : IEvent
    {
        public Guid Id { get; set; }
        public int ReadableId { get; set; }
    }
}
