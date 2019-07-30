using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.HealthRisks
{
    public class AllHealthRisks : IQueryFor<HealthRisk>
    {
        readonly IReadModelRepositoryFor<HealthRisk> _repositoryForHealthRisk;

        public AllHealthRisks(IReadModelRepositoryFor<HealthRisk> repositoryForHealthRisk)
        {
            _repositoryForHealthRisk = repositoryForHealthRisk;
        }

        public IQueryable<HealthRisk> Query => _repositoryForHealthRisk.Query;
    }
}
