using System;
using Dolittle.Events;

namespace Events.External
{
    public class HealthRiskModified : IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ReadableId { get; set; }
    }
}