using Dolittle.Commands.Handling;
using Dolittle.Domain;
using System;

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
            var healthRisks = _aggregateRootRepoForHealthRisks.Get(cmd.HealthRiskId.Value);
            healthRisks.Add(cmd.HealthRiskName, cmd.HealthRiskId, cmd.HealthRiskNumber);
        }
        
    }
}
