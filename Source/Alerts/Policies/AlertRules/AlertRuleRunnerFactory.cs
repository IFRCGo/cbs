using System.Collections.Generic;
using System.Linq;
using Read;
using Read.AlertRules;

namespace Policies.AlertRules
{
    public class AlertRuleRunnerFactory : IAlertRuleRunnerFactory
    {
        private readonly IAllQuery<AlertRule> _alertRulesAllQuery;

        public AlertRuleRunnerFactory(IAllQuery<AlertRule> alertRulesAllQuery)
        {
            _alertRulesAllQuery = alertRulesAllQuery;
        }

        public IEnumerable<IAlertRuleRunner> GetRelevantAlertRules(int healthRiskNumber)
        {
            //TODO filter by healthrisk
            return _alertRulesAllQuery.Query.Select(r => new AlertRuleRunner(r));
        }
    }
}
