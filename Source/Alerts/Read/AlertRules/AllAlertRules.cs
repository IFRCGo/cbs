using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.AlertRules
{
    public class AllAlertRules : IQueryFor<AlertRule>
    {
        private readonly IReadModelRepositoryFor<AlertRule> _collection;

        public AllAlertRules(IReadModelRepositoryFor<AlertRule> collection)
        {
            _collection = collection;
        }

        public IQueryable<AlertRule> Query => _collection.Query;
    }
}