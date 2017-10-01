using Events.External;

namespace Read.Disease
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
            var user = _healthRisks.GetById(@event.Id);
            if (user == null)
            {
                user = new Read.Disease.HealthRisk()
                {
                    Id = @event.Id,
                    Name = @event.Name,
                    Code = @event.Code
                };
            }
            else
            {
                user.Id = @event.Id;
                user.Name = @event.Name;
                user.Code = @event.Code;
            }
            _healthRisks.Save(user);
        }
    }
}
