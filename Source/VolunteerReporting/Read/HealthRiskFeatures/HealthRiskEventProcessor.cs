using Events.External;
using doLittle.Events.Processing;

namespace Read.HealthRiskFeatures
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
            var healthRisk = _healthRisks.GetById(@event.Id) ?? new HealthRisk(@event.Id);
            healthRisk.ReadableId = @event.ReadableId;
            healthRisk.Name = @event.Name;
            _healthRisks.Save(healthRisk);
        }
    }
}