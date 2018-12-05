using Concepts.HealthRisks;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.HealthRisks;

namespace Domain.HealthRisks
{
    public class HealthRisk : AggregateRoot
    {
        public HealthRisk(EventSourceId id) : base(id)
        {
        }
        public void CreateHealthRisk(
            HealthRiskName name,
            CaseDefinition caseDefinition,
            HealthRiskNumber healthRiskNumber)
        {
            Apply(new HealthRiskCreated(EventSourceId, name, caseDefinition, healthRiskNumber));
        }

        public void SetName(string name)
        {
            Apply(new HealthRiskNameSet(name));
        }

        public void OverrideName(string name)
        {
            Apply(new HealthRiskNameOverridden(name));
        }


        public void SetCaseDefinition(string name)
        {
            Apply(new HealthRiskCaseDefinitionSet(name));
        }

        public void OverrideCaseDefinition(string name)
        {
            Apply(new HealthRiskCaseDefinitionOverridden(name));
        }

        public void AddThresholdToHealthRisk(int threshold)
        {
            Apply(new ThresholdAddedToHealthRIsk(EventSourceId, threshold));
        }

        public void DeleteHealthRisk()
        {
            Apply(new HealthRiskDeleted(EventSourceId));
        }

        public void AddKeyMessage(KeyMessage keyMessage)
        {
            Apply(new KeyMessageAddedToHealthRisk(EventSourceId, keyMessage.Id, keyMessage.Message, keyMessage.Language));
        }
    }
}