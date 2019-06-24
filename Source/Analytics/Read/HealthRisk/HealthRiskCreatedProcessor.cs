using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Concepts;
using Events.HealthRisk;

namespace Read.HealthRisk
{
    public class HealthRiskCreatedProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<HealthRisks> _repositoryForHealthRisks;

        public HealthRiskCreatedProcessor(
            IReadModelRepositoryFor<HealthRisks> repositoryForHealthRisks            
        )
        {
            _repositoryForHealthRisks = repositoryForHealthRisks;
        }
        
        [EventProcessor("c5450b8a-f487-656e-1d0d-ea07073abc1d")]
        public void Process(HealthRiskCreated @event)
        { 
            var healthRisks = _repositoryForHealthRisks.GetById(@event.HealthRiskId);
            if(healthRisks == null)
            {
                healthRisks = new HealthRisks
                {
                    Id = @event.HealthRiskId,
                    AllHealthRisks = new []
                    {
                        new Concepts.HealthRisk.HealthRisk(@event.HealthRiskName)
                    }
                };
                _repositoryForHealthRisks.Insert(healthRisks);
            }
            else 
            {
                healthRisks.AllHealthRisks.Add(new Concepts.HealthRisk.HealthRisk(@event.HealthRiskName));

                _repositoryForHealthRisks.Update(healthRisks);
            }

        }
        
    }
}
