using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Admin.HealthRisks;

namespace Read.HealthRisks
{
    public class EventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<HealthRisk> _healthRisks;

        public EventProcessor(IReadModelRepositoryFor<HealthRisk> healthRisks)
        {
            _healthRisks = healthRisks;
        }
        
        [EventProcessor("9c62046d-eb9a-ab1d-8d56-af179f20cfc2")]
        public void Process(HealthRiskCreated @event)
        { 
            var healthRisk = _healthRisks.GetById(@event.Id);

                healthRisk = new HealthRisk
                {
                    Id = @event.Id,
                    Name = @event.Name,
                    HealthRiskNumber = @event.HealthRiskNumber
                };
                _healthRisks.Insert(healthRisk);
        }
        
        [EventProcessor("d2a2762d-aa9e-48dd-6667-629e2d64f16a")]
        public void Process(HealthRiskModified @event)
        { 
            _healthRisks.Update(new HealthRisk {
                Id = @event.Id,
                Name = @event.Name
            });
        }
        
    }
}
