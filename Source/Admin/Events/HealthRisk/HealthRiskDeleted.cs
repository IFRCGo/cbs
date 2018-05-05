using System;
using Dolittle.Events;

namespace Events.HealthRisk
{
    public class HealthRiskDeleted : IEvent
    {
        public Guid HealthRiskId { get; set; }
    }
}