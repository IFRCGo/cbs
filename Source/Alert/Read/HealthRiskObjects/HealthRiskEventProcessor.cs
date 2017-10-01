using Events.External;

namespace Read.HealthRiskObjects
{
    public class HealthRiskEventProcessor : Infrastructure.Events.IEventProcessor
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
