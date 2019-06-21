using System;
using Dolittle.Events;

namespace Events
{
    public class HealthRiskCreated : IEvent
    {
        public HealthRiskCreated(Guid healthRiskId, string healthRiskName)
        {
            HealthRiskId = healthRiskId;
            HealthRiskName = healthRiskName;
        }

        public Guid HealthRiskId { get; }
        public string HealthRiskName { get; }

    }
}
