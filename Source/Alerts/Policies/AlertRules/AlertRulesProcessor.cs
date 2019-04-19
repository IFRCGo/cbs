/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Events.Processing;
using Dolittle.Domain;
using Domain.Alerts;
using Dolittle.Runtime.Commands.Coordination;
using System;
using System.Collections.Generic;
using Read.Reports;
using Events.Reports;
using Dolittle.ReadModels;
using System.Linq;

namespace Policies.AlertRules
{
    /// <summary>
    /// Class for processing external event <see cref="ReportRegistered"/>
    /// </summary>
    public class AlertRulesProcessor : ICanProcessEvents
    {
        private readonly IAggregateRootRepositoryFor<Domain.Alerts.Alerts> _alertsAggregateRootRepository;
        private readonly IReadModelRepositoryFor<Read.Reports.Report> _reportRepository;
        private readonly IReadModelRepositoryFor<Read.AlertRules.AlertRule> _alertRuleRepository;
        private readonly ICommandContextManager _commandContextManager;
        public AlertRulesProcessor(

            ICommandContextManager commandContextManager,
            IAggregateRootRepositoryFor<Domain.Alerts.Alerts> alertsAggregateRootRepository,
            IReadModelRepositoryFor<Read.Reports.Report> reportRepository,
            IReadModelRepositoryFor<Read.AlertRules.AlertRule> alertRuleRepository
            
            )
        {
            _commandContextManager = commandContextManager;
            _alertsAggregateRootRepository = alertsAggregateRootRepository;
            _reportRepository = reportRepository;
            _alertRuleRepository = alertRuleRepository;
        }

        [EventProcessor("1df8a07e-74b9-43fd-aa01-68ec4ae7130d")]
        public void Process(ReportRegistered @event)
        {
            var transaction = _commandContextManager.EstablishForCommand(
                new Dolittle.Runtime.Commands.CommandRequest(
                    Guid.NewGuid(), 
                    Guid.NewGuid(), 
                    1, 
                    new Dictionary<string, object>()));
            var root = _alertsAggregateRootRepository.Get(@event.CaseReportId);
            var item = _reportRepository.GetById(@event.ReportId);
            var relevantAlertRules = GetRelevantAlertRules(item.HealthRiskNumber);

            foreach (var alertRule in relevantAlertRules)
            {
                TriggerAlerts(alertRule, root);
            }
           
            transaction.Commit();
        }
        IEnumerable<Read.AlertRules.AlertRule> GetRelevantAlertRules(int healthRiskNumber) => 
            _alertRuleRepository.Query.Where(r => r.HealthRiskId == healthRiskNumber);
        
        void TriggerAlerts(Read.AlertRules.AlertRule alertRule, Domain.Alerts.Alerts root) 
        {
            int casesThreshold = alertRule.NumberOfCasesThreshold;
            int healthRiskNumber = alertRule.HealthRiskId;
            TimeSpan alertRuleInterval = new TimeSpan(alertRule.ThresholdTimeframeInHours, 0, 0);

            DateTimeOffset horizon = DateTimeOffset.UtcNow - alertRuleInterval;
            var reportIds = _reportRepository.Query.Where(
                c => c.Timestamp >= horizon && c.HealthRiskNumber == healthRiskNumber)
                .Select(_ => _.Id).ToList();

            if(reportIds.Count() >= casesThreshold)
            {
                root.OpenAlert(
                    Guid.NewGuid(),
                    alertRule.Id,
                    reportIds
                );
            }
            

        }
    }
}
