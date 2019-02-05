/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.AlertRules;

namespace Read.AlertRules
{
    public class AlertRuleEventProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<AlertRule> _alertRules;

        public AlertRuleEventProcessor(IReadModelRepositoryFor<AlertRule> alertRules)
        {
            _alertRules = alertRules;
        }

        [EventProcessor("5E82FBA1-F4D0-44BD-A954-0C8F2D490F25")]
        public void Process(AlertRuleCreated @event)
        {
            var alertRule = new AlertRule
            {
                Id = @event.Id,
                HealthRiskId = @event.HealthRiskId,
                DistanceBetweenCasesInMeters = @event.DistanceBetweenCasesInMeters,
                AlertRuleName = @event.AlertRuleName,
                NumberOfCasesThreshold = @event.NumberOfCasesThreshold,
                ThresholdTimeframeInHours = @event.ThresholdTimeframeInHours,
                };
            _alertRules.Insert(alertRule);
        }

        [EventProcessor("D29C863C-F123-4689-9ED4-DB3EB12A47D3")]
        public void Process(AlertRuleUpdated @event)
        {
            var alertRule = _alertRules.GetById(@event.Id);
            alertRule.AlertRuleName = @event.AlertRuleName;
            alertRule.DistanceBetweenCasesInMeters = @event.DistanceBetweenCasesInMeters;
            alertRule.HealthRiskId = @event.HealthRiskId;
            alertRule.NumberOfCasesThreshold = @event.NumberOfCasesThreshold;
            alertRule.ThresholdTimeframeInHours = @event.ThresholdTimeframeInHours;
            _alertRules.Update(alertRule);
        }

        [EventProcessor("27907C3D-C338-46D9-A069-067C8307095B")]
        public void Process(AlertRuleDeleted @event)
        {
            var alertRule = _alertRules.GetById(@event.AlertRuleId);
            _alertRules.Delete(alertRule);
        }
    }
}