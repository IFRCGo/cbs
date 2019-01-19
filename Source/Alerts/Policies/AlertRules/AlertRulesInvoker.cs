using System;
using Dolittle.Domain;
using Read;
using Read.AlertRules;
using Read.CaseReports;
using AlertsDomain = Domain.Alerts;

namespace Policies.AlertRules
{
    public class AlertRulesInvoker : ICaseNotificationService
    {
        private readonly IAllQuery<Case> _casesAllQuery;
        private readonly IAlertRuleRunnerFactory _alertRuleRunnerFactory;
        private readonly IAggregateRootRepositoryFor<AlertsDomain.Alerts> _aggregateRootRepository;

        public AlertRulesInvoker(
            IAllQuery<Case> casesAllQuery, 
            IAlertRuleRunnerFactory alertRuleRunnerFactory,
            IAggregateRootRepositoryFor<AlertsDomain.Alerts> aggregateRootRepository)
        {
            _casesAllQuery = casesAllQuery;
            _alertRuleRunnerFactory = alertRuleRunnerFactory;
            _aggregateRootRepository = aggregateRootRepository;
        }

        public void Changed(Case updatedItem)
        {
            //TODO if there's open alert with same Health risk, we should just add the case to that alert.
            var alertRules = _alertRuleRunnerFactory.GetRelevantAlertRules(updatedItem.HealthRiskNumber);
            foreach (IAlertRuleRunner alertRunner in alertRules)
            {
                AlertRuleRunResult result = alertRunner.RunAlertRule(_casesAllQuery);
                if (result.Triggered)
                {
                    var alertId = Guid.NewGuid();
                    var alertRuleAggrRoot = _aggregateRootRepository.Get(alertId);
                    alertRuleAggrRoot.OpenAlert(
                        alertId,
                        result.AlertRuleId,
                        result.Cases
                        );
                }
            }
        }
    }
}
