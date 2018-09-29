using Dolittle.Events;

namespace Events.HealthRisks
{
    public class HealthRiskCaseDefinitionSet : IEvent 
    {
        public HealthRiskCaseDefinitionSet(string definition) => Definition = definition;
        public string Definition { get; }
    }
}