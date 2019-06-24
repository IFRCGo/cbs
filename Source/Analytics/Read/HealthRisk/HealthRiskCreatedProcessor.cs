using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.HealthRisk;

namespace Read.HealthRisk
{
    public class HealthRiskCreatedProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<HealthRisk> _repositoryForHealthRisks;

        public HealthRiskCreatedProcessor(
            IReadModelRepositoryFor<HealthRisk> repositoryForHealthRisks            
        )
        {
            _repositoryForHealthRisks = repositoryForHealthRisks;
        }
        
        [EventProcessor("c5450b8a-f487-656e-1d0d-ea07073abc1d")]
        public void Process(HealthRiskCreated @event)
        { 
            var healthRisk = _repositoryForHealthRisks.GetById(@event.HealthRiskId); //currently only one list for HealthRisks
            if(healthRisk == null)
            {
                healthRisk = new HealthRisk
                {
                    Id = @event.HealthRiskId,
                    HealthRiskName = @event.HealthRiskName,
                    HealthRiskNumber = @event.HealthRiskNumber
                    
                };
                _repositoryForHealthRisks.Insert(healthRisk);
            }
            else 
            {
                healthRisk.HealthRiskName = @event.HealthRiskName;
                healthRisk.HealthRiskNumber = @event.HealthRiskNumber;

                _repositoryForHealthRisks.Update(healthRisk);
            }

        }
        
    }
}
