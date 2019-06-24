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

        public void Add(HealthRiskName name, HealthRiskNumber number)
        {
            var createdEvent = new HealthRiskCreated(
                EventSourceId,
                name,
                number
            );

            Apply(createdEvent);
        }
    }
}
