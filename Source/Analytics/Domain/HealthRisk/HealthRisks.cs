using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Concepts;
using Events.HealthRisk;

namespace Domain.HealthRisk
{
    public class HealthRisks : AggregateRoot
    {
        public HealthRisks(EventSourceId id) : base(id)
        { 
            
        }

        public void Add(HealthRiskName name)
        {
            var createdEvent = new HealthRiskCreated(
                EventSourceId,
                name
            );

            Apply(createdEvent);
        }
    }
}
