using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Admin.HealthRisk;

namespace Read.HealthRisk
{
    public class HealthRiskCreatedEventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<HealthRisk> _repositoryForHealthRisks;

        public HealthRiskCreatedEventProcessor(
            IReadModelRepositoryFor<HealthRisk> repositoryForHealthRisks      
        )
        {
            _repositoryForHealthRisks = repositoryForHealthRisks;
        }
        
        [EventProcessor("9c62046d-eb9a-ab1d-8d56-af179f20cfc2")]
        public void Process(HealthRiskCreated @event)
        { 
            var healthRisk = _repositoryForHealthRisks.GetById(@event.Id);

                healthRisk = new HealthRisk
                {
                    Id = @event.Id,
                    Name = @event.Name,
                    HealthRiskNumber = @event.HealthRiskNumber
                };
                _repositoryForHealthRisks.Insert(healthRisk);

        }
        
    }
}
