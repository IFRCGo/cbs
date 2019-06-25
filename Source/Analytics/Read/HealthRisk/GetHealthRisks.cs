using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.HealthRisk
{
    public class GetHealthRisks: IQueryFor<HealthRisk>
    {
        readonly IReadModelRepositoryFor<HealthRisk> _repositoryForHealthRisks;
        public GetHealthRisks(IReadModelRepositoryFor<HealthRisk> repositoryForHealthRisks)
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
