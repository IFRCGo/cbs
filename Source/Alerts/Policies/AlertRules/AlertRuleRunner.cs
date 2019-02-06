using System;
using System.Collections.Generic;
using System.Linq;
using Dolittle.ReadModels;
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
        public AlertRuleRunResult RunAlertRule(IReadModelRepositoryFor<Case> casesRepository)
        {
            int casesThreshold = _alertRule.NumberOfCasesThreshold;
            int healthRiskNumber = _alertRule.HealthRiskId;
            TimeSpan alertRuleInterval = new TimeSpan(_alertRule.ThresholdTimeframeInHours, 0, 0);

            DateTimeOffset horizont = DateTimeOffset.UtcNow - alertRuleInterval;
            List<Guid> cases = casesRepository.Query.Where(
                c => c.Timestamp >= horizont && c.HealthRiskNumber == healthRiskNumber)
                .AsEnumerable<Case>()
                .Select(c => c.Id).ToList();

            if(cases.Count < casesThreshold)
            {
                return AlertRuleRunResult.NotTriggeredResult;
            }

            return new AlertRuleRunResult(cases, _alertRule.Id);
        }
    }
}
