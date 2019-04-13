using System;
using Dolittle.Events;

namespace Events.Admin.HealthRisks
{
    public class HealthRiskCreated : IEvent
    {
        public Guid Id { get; }
        public string Name { get; }
        public string CaseDefinition { get; }
        public int HealthRiskNumber { get; }

        public HealthRiskCreated(Guid id, string name, string caseDefinition, int healthRiskNumber)
        {
            Id = id;
            Name = name;
            CaseDefinition = caseDefinition;
            HealthRiskNumber = healthRiskNumber;
        }
    }
}
