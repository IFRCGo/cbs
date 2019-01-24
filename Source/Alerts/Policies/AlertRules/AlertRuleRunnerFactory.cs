using System.Collections.Generic;
using System.Linq;
using Dolittle.ReadModels;
using Read.AlertRules;

namespace Policies.AlertRules
{
    public class AlertRuleRunnerFactory : IAlertRuleRunnerFactory
    {
        private readonly IReadModelRepositoryFor<AlertRule> _alertRuleRepository;

        public AlertRuleRunnerFactory(IReadModelRepositoryFor<AlertRule> alertRulesAllQuery)
        {
            _alertRuleRepository = alertRulesAllQuery;
        }

        public IEnumerable<IAlertRuleRunner> GetRelevantAlertRules(int healthRiskNumber)
        {
            return _alertRuleRepository.Query.Where(r => r.HealthRiskId == healthRiskNumber)
                .AsEnumerable<AlertRule>()
                .Select(r => new AlertRuleRunner(r));
        }
    }
}
