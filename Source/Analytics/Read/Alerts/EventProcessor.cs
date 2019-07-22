/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Alerts;

namespace Read.Alerts
{
    public class EventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<Alert> _repositoryForAlert;
        readonly IReadModelRepositoryFor<AlertRule> _repositoryForAlertRule;

        public EventProcessor(
            IReadModelRepositoryFor<Alert> repositoryForAlert,            
            IReadModelRepositoryFor<AlertRule> repositoryForAlertRule
        )
        {
            _repositoryForAlert = repositoryForAlert;
            _repositoryForAlertRule = repositoryForAlertRule;
        }
        
        [EventProcessor("95cb8a00-1958-d570-5813-15f5ded919f5")]
        public void Process(AlertOpened @event)
        {
            var rule = _repositoryForAlertRule.GetById(@event.AlertRuleId);
            _repositoryForAlert.Insert(new Alert()
            {
                Id = @event.AlertId,
                AlertNumber = @event.AlertNumber,
                AlertRuleId = @event.AlertRuleId,
                HealthRiskName = rule.HealthRiskName
            });
        }
        
        [EventProcessor("5bd5afd6-c87b-2531-3c11-51bfe2e43454")]
        public void Process(AlertRuleCreated @event)
        { 
            _repositoryForAlertRule.Insert(new AlertRule()
            {
                Id = @event.Id,
                HealthRiskName = @event.AlertRuleName
            });
        }
        
        [EventProcessor("719d6548-c65d-c728-0662-e000361cba3f")]
        public void Process(AlertRuleUpdated @event)
        { 
            var rule = _repositoryForAlertRule.GetById(@event.Id);
            rule.HealthRiskName = @event.AlertRuleName;
            _repositoryForAlertRule.Update(rule);
        }
    }
}
