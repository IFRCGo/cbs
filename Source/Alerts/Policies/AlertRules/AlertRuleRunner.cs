using System;
using System.Collections.Generic;
using System.Linq;
using Dolittle.ReadModels;
using Read.AlertRules;
using Read.Reports;

namespace Policies.AlertRules
{
    public class AlertRuleRunner : IAlertRuleRunner
    {
        private readonly AlertRule _alertRule;

        public AlertRuleRunner(AlertRule alertRule)
        {
            _alertRule = alertRule;
        }
        public AlertRuleRunResult RunAlertRule(IReadModelRepositoryFor<Report> reportsRepository)
        {
            int casesThreshold = _alertRule.NumberOfCasesThreshold;
            int healthRiskNumber = _alertRule.HealthRiskId;
            TimeSpan alertRuleInterval = new TimeSpan(_alertRule.ThresholdTimeframeInHours, 0, 0);

            DateTimeOffset horizont = DateTimeOffset.UtcNow - alertRuleInterval;
            List<Guid> reports = reportsRepository.Query.Where(
                c => c.Timestamp >= horizont && c.HealthRiskNumber == healthRiskNumber)
                .AsEnumerable<Report>()
                .Select(c => c.Id).ToList();

            if(reports.Count < casesThreshold)
            {
                return AlertRuleRunResult.NotTriggeredResult;
            }

            return new AlertRuleRunResult(reports, _alertRule.Id);
        }
    }
}
