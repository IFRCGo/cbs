using System;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.Admin.Reporting.HealthRisks;

namespace Domain.TestData.HealthRisks
{
    public class HealtRisk : AggregateRoot
    {
        public HealtRisk(EventSourceId id) : base(id)
        {
        }

        public void HealthRisk(Guid healthRiskId, string healthRiskName, string healthRiskCaseDefinition, int healthRiskReadableId)
        {
            Apply(new HealthRiskCreated(healthRiskId, healthRiskName, healthRiskCaseDefinition, healthRiskReadableId));
        }
    }
}