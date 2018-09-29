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


        public void CreateHealthRisk(string caseDefinition, string communityCase, string keyMessage, string name, string note, int readableId)
        {
            Apply(new HealthRiskCreated(EventSourceId, name, readableId, caseDefinition, note, communityCase, keyMessage));
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
    }
}