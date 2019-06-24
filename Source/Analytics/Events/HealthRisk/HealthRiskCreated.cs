using System;
using Dolittle.Events;

namespace Events.HealthRisk
{
    public class HealthRiskCreated : IEvent
    {
        public HealthRiskCreated(Guid healthRiskId, string healthRiskName, int healthRiskNumber)
        {
            HealthRiskId = healthRiskId;
            HealthRiskName = healthRiskName;
            HealthRiskNumber = healthRiskNumber;
        }

        public Guid HealthRiskId { get; }
        public string HealthRiskName { get; }
        public int HealthRiskNumber { get; }

    }
}
