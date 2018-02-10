using Events.External;
using doLittle.Events.Processing;
using System.Threading.Tasks;
using System;
namespace Read.HealthRisks
{
    public class HealthRiskEventProcessor : ICanProcessEvents
    {
        readonly IHealthRisks _healthRisks;

        public HealthRiskEventProcessor(IHealthRisks healthRisks)
        {
            _healthRisks = healthRisks;
        }

        public async Task Process(HealthRiskCreated @event)
        {
            var healthRisk = _healthRisks.GetById(@event.Id) ?? new HealthRisk(@event.Id);
            healthRisk.ReadableId = @event.ReadableId;
            healthRisk.Name = @event.Name;
            await _healthRisks.Save(healthRisk);
        }
    }
}