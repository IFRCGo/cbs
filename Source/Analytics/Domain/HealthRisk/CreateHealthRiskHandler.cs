using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.HealthRisk
{
    public class CreateHealthRiskHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<HealthRisks>  _aggregateRootRepoForHealthRisks;

        public CreateHealthRiskHandler(
            IAggregateRootRepositoryFor<HealthRisks>  aggregateRootRepoForHealthRisks            
        )
        {
             _aggregateRootRepoForHealthRisks =  aggregateRootRepoForHealthRisks;
        }

        public void Handle(CreateHealthRisk cmd)
        {
            var healthRisk = _aggregateRootRepoForHealthRisks.Get(cmd.HealthRiskGuid.Value);
            healthRisk.Add(cmd.HealthRiskName);
        }
        
    }
}
