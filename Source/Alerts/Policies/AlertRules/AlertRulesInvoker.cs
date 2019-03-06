using System;
using System.Collections.Generic;
using Dolittle.Domain;
using Dolittle.ReadModels;
using Dolittle.Runtime.Commands.Coordination;
using Read;
using Read.Reports;
using AlertsDomain = Domain.Alerts;

namespace Policies.AlertRules
{
    public class AlertRulesInvoker : IReportNotificationService
    {
        private readonly ICommandContextManager _commandContextManager;
        private readonly IReadModelRepositoryFor<Report> _reportsRepository;
        private readonly IAlertRuleRunnerFactory _alertRuleRunnerFactory;
        private readonly IAggregateRootRepositoryFor<AlertsDomain.Alerts> _aggregateRootRepository;

        public AlertRulesInvoker(
            ICommandContextManager commandContextManager,
            IReadModelRepositoryFor<Report> reportsRepository, 
            IAlertRuleRunnerFactory alertRuleRunnerFactory,
            IAggregateRootRepositoryFor<AlertsDomain.Alerts> aggregateRootRepository)
        {
            _commandContextManager = commandContextManager;
            _reportsRepository = reportsRepository;
            _alertRuleRunnerFactory = alertRuleRunnerFactory;
            _aggregateRootRepository = aggregateRootRepository;
        }

        public void Changed(Report updatedItem)
        {
            //TODO if there's open alert with same Health risk, we should just add the case to that alert.
            var alertRules = _alertRuleRunnerFactory.GetRelevantAlertRules(updatedItem.HealthRiskNumber);
            foreach (IAlertRuleRunner alertRunner in alertRules)
            {
                AlertRuleRunResult result = alertRunner.RunAlertRule(_reportsRepository);
                if (result.Triggered)
                {
                    var alertId = Guid.NewGuid();
                    var transaction = _commandContextManager.EstablishForCommand(
                        new Dolittle.Runtime.Commands.CommandRequest(
                            Guid.NewGuid(), 
                            Guid.NewGuid(), 
                            1, 
                            new Dictionary<string, object>()));

                    var alertRuleAggrRoot = _aggregateRootRepository.Get(alertId);
                    alertRuleAggrRoot.OpenAlert(
                        alertId,
                        result.AlertRuleId,
                        result.Cases
                        );
                    transaction.Commit();
                }
            }
        }
    }
}
