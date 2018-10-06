using Dolittle.Events;

namespace Events.HealthRisks
{
    public class HealthRiskCaseDefinitionOverridden : IEvent 
    {
        public HealthRiskCaseDefinitionOverridden(string definition) => Definition = definition;
        public string Definition { get; }
    }
}