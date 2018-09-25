using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.HealthRisk;

namespace Domain.HealthRisk
{
    public class HealthRisk : AggregateRoot
    {
        public HealthRisk(EventSourceId id) : base(id)
        {
        }


        public void CreateHealthRisk(string caseDefinition, string communityCase, string keyMessage, 
            string name, string note, int readableId)
        {
            Apply(new HealthRiskCreated(EventSourceId, name, readableId, caseDefinition, note, communityCase, keyMessage));
        }

        public void AddThresholdToHealthRisk(int threshold)
        {
            Apply(new ThresholdAddedToHealthRIsk(EventSourceId, threshold));
        }

        public void ModifyHealthRisk(string caseDefinition, string communityCase, string keyMessage, string name, string note, int readableId)
        {
            Apply(new HealthRiskModified(EventSourceId, name, readableId, caseDefinition, note, communityCase, keyMessage));
        }

        public void DeleteHealthRisk()
        {
            Apply(new HealthRiskDeleted(EventSourceId));
        }
    }
}