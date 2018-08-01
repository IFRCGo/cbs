using System.Linq;
using Dolittle.Queries;

namespace Read.HealthRisks.Queries
{
    public class AllHealthRisks : IQueryFor<HealthRisk>
    {
        private readonly IHealthRisks _collection;

        public AllHealthRisks(IHealthRisks collection)
        {
            _collection = collection;
        }

        public IQueryable<HealthRisk> Query => _collection.Query.Where(_ => true);
    }
}