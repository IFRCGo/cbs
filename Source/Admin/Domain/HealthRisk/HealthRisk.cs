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
            Apply(new HealthRiskCreated
            {
                Id = EventSourceId,
                CaseDefinition = caseDefinition,
                ReadableId = readableId,
                CommunityCase = communityCase,
                KeyMessage = keyMessage,
                Note = note,
                Name = name
            });
        }

        public void AddThresholdToHealthRisk(int threshold)
        {
            Apply(new ThresholdAddedToHealthRIsk(EventSourceId, threshold));
        }

        public void ModifyHealthRisk(string caseDefinition, string communityCase, string keyMessage, string name, string note, int readableId)
        {
            Apply(new HealthRiskModified
            {
                Id = EventSourceId,
                CaseDefinition = caseDefinition,
                ReadableId = readableId,
                CommunityCase = communityCase,
                KeyMessage = keyMessage,
                Note = note,
                Name = name
            });
        }

        public void DeleteHealthRisk()
        {
            Apply(new HealthRiskDeleted
            {
                HealthRiskId = EventSourceId
            });
        }
    }
}