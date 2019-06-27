using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.HealthRisk
{
    public class AllHealthRisks: IQueryFor<HealthRisk>
    {
        readonly IReadModelRepositoryFor<HealthRisk> _repositoryForHealthRisks;
        public AllHealthRisks(IReadModelRepositoryFor<HealthRisk> repositoryForHealthRisks)
        {
            _repositoryForHealthRisks = repositoryForHealthRisks;
        }

        public IQueryable<HealthRisk> Query
        {
            get
            {
                return _repositoryForHealthRisks.Query;
            }
        }
    }
}
