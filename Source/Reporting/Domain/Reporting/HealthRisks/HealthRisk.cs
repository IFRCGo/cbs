using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.Admin.Reporting.HealthRisks;

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
            Apply(new HealthRiskCreated(EventSourceId.Value, readableId, name));
        }
    }
}
