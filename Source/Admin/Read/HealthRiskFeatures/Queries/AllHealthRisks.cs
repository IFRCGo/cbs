using System.Linq;
using Dolittle.Queries;

namespace Read.HealthRiskFeatures.Queries
{
    public class AllHealthRisks : IQueryFor<HealthRisk>
    {
        readonly IHealthRisks _collection;

        public AllHealthRisks(IHealthRisks collection)
        {
            _collection = collection;
        }

        public IQueryable<HealthRisk> Query => _collection.Query;
    }
}