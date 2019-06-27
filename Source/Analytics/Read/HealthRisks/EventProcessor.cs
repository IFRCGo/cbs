using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Admin.HealthRisks;

namespace Read.HealthRisks
{
    public class EventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<HealthRiskName> _healthRisks;

        public EventProcessor(IReadModelRepositoryFor<HealthRiskName> healthRisks)
        {
            _healthRisks = healthRisks;
        }
        
        [EventProcessor("15143c92-10c5-5f79-4148-fcc6060fab4a")]
        public void Process(HealthRiskCreated @event)
        {
            _healthRisks.Insert(new HealthRiskName {
                Id = @event.Id,
                Name = @event.Name
            });
        }
        
        [EventProcessor("d2a2762d-aa9e-48dd-6667-629e2d64f16a")]
        public void Process(HealthRiskModified @event)
        { 
            _healthRisks.Update(new HealthRiskName {
                Id = @event.Id,
                Name = @event.Name
            });
        }
        
    }
}
