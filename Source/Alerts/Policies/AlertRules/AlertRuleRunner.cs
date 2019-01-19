using System;
using System.Collections.Generic;
using System.Linq;
using Read;
using Read.AlertRules;
using Read.CaseReports;

namespace Policies.AlertRules
{
    public class AlertRuleRunner : IAlertRuleRunner
    {
        private readonly AlertRule _alertRule;

        public AlertRuleRunner(AlertRule alertRule)
        {
            _alertRule = alertRule;
        }
        public AlertRuleRunResult RunAlertRule(IAllQuery<Case> casesAllQuery)
        {
            // TODO Get from AlertRule
            int casesThreshold = 1;
            int healthRiskNumber = 1;
            TimeSpan alertRuleInterval = new TimeSpan(24, 0, 0);

            DateTimeOffset horizont = DateTimeOffset.UtcNow - alertRuleInterval;
            List<Guid> cases = casesAllQuery.Query.Where(
                c => c.Timestamp >= horizont && c.HealthRiskNumber == healthRiskNumber)
                .Select(c => c.CaseId).ToList();

            if(cases.Count < casesThreshold)
            {
                return AlertRuleRunResult.NotTriggeredResult;
            }

            return new AlertRuleRunResult(cases, _alertRule.Id);
        }
    }
}
