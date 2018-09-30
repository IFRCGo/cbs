using Dolittle.Events.Processing;
using Concepts.HealthRisk;
using Events.Admin.HealthRisks;

namespace Read.HealthRisks
{
    public class HealthRiskEventProcessor : ICanProcessEvents
    {
        readonly IHealthRisks _healthRisks;

        public HealthRiskEventProcessor(IHealthRisks healthRisks)
        {
            _healthRisks = healthRisks;
        }
        [EventProcessor("ee7504ec-9103-4d59-bda3-7c95dd0b617b")]
        public void Process(HealthRiskCreated @event)
        {
            _healthRisks.SaveHealthRisk(@event.Id, @event.ReadableId, @event.Name);
        }
        [EventProcessor("a82b73a6-cf23-48ad-9047-fc720a9a8054")]
        public void Process(HealthRiskModified @event)
        {
            var updateResult = _healthRisks.UpdateHealthRisk(@event.Id, @event.ReadableId, @event.Name);
        }
        [EventProcessor("2b66cf4d-ac12-4a08-957b-bed6dfae88de")]
        public void Process(HealthRiskDeleted @event)
        {
            _healthRisks.Delete(_ => _.Id == (HealthRiskId)@event.HealthRiskId);
        }
    }
}
