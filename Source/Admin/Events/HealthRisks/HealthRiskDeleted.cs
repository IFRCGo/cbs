using System;
using Dolittle.Events;

namespace Events.HealthRisks
{
    public class HealthRiskDeleted : IEvent
    {
        public HealthRiskDeleted(Guid healthRiskId)
        {
            HealthRiskId = healthRiskId;
        }
        public Guid HealthRiskId { get; }
    }
}