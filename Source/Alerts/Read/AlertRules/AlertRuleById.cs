using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.AlertRules
{
    public class AlertRuleById : IQueryFor<AlertRule>
    {
        private readonly IReadModelRepositoryFor<AlertRule> _collection;

        public Guid RuleId { get; set; }

        public AlertRuleById(IReadModelRepositoryFor<AlertRule> collection)
        {
            _collection = collection;
        }

        public IQueryable<AlertRule> Query => _collection.Query.Where(r => r.Id == RuleId);
    }
}