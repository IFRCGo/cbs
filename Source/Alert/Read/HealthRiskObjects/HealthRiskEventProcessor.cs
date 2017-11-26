using Events.External;
using doLittle.Events.Processing;

namespace Read.HealthRiskObjects
{
    public class HealthRiskEventProcessor : ICanProcessEvents
    {
        private readonly IHealthRisks _healthRisks;

        public HealthRiskEventProcessor(IHealthRisks healthRisks)
        {
            _healthRisks = healthRisks;
        }

        public void Process(HealthRiskCreatedEvent @event)
        {
            var healthRisk = _healthRisks.GetById(@event.Id);
            if (healthRisk == null)
            {
                healthRisk = new HealthRisk()
                {
                    Id = @event.Id,
                    Name = @event.Name,
                    Code = @event.Code
                };
            }
            else
            {
                healthRisk.Id = @event.Id;
                healthRisk.Name = @event.Name;
                healthRisk.Code = @event.Code;
            }
            _healthRisks.Save(healthRisk);
        }
    }
}
