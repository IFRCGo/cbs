using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.Management.HealthRisks;

namespace Domain.Reporting.HealthRisks
{
    public class HealthRisk : AggregateRoot
    {
        public HealthRisk(EventSourceId id) : base(id)
        {
        }
        public void CreateHealthRisk(
            string name,
            int readableId)
        {
            Apply(new HealthRiskRegistered(EventSourceId.Value, readableId, name));
        }
    }
}
