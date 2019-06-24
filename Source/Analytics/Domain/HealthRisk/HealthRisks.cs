using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Concepts.HealthRisk;
using Events.HealthRisk;

namespace Domain.HealthRisk
{
    public class HealthRisks : AggregateRoot
    {
        public HealthRisks(EventSourceId id) : base(id)
        { 
            
        }

        public void Add(HealthRiskName name, HealthRiskId id, HealthRiskNumber number)
        {
            var createdEvent = new HealthRiskCreated(
                name,
                id,
                number
            );

            Apply(createdEvent);
        }
    }
}
