using Events.External;
using Dolittle.Events.Processing;
using Concepts.HealthRisk;

namespace Read.HealthRisks
{
    public class HealthRiskEventProcessor : ICanProcessEvents
    {
        readonly IHealthRisks _healthRisks;

        public HealthRiskEventProcessor(IHealthRisks healthRisks)
        {
            _healthRisks = healthRisks;
        }

        public void Process(HealthRiskCreated @event)
        {
            _healthRisks.SaveHealthRisk(@event.Id, @event.ReadableId, @event.Name);
        }

        public void Process(HealthRiskModified @event)
        {
            var updateResult = _healthRisks.UpdateHealthRisk(@event.Id, @event.ReadableId, @event.Name);
        }

        public void Process(HealthRiskDeleted @event)
        {
            _healthRisks.Delete(_ => _.Id == (HealthRiskId)@event.HealthRiskId);
        }
    }
}
