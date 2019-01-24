/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/


using Concepts.AlertRules;
using Concepts.HealthRisks;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.AlertRules;

namespace Domain.AlertRules
{
    public class AlertRule : AggregateRoot
    {
        public AlertRule(EventSourceId id) : base(id)
        {
        }

        public void CreateAlertRule(AlertRuleName alertRuleName, HealthRiskNumber healthRiskNumber,
            NumberOfCasesThreshold numberOfCasesThreshold, DistanceBetweenCasesInMeters distanceBetweenCasesInMeters,
            ThresholdTimeframeInHours thresholdTimeframeInHours)
        {
            Apply(new AlertRuleCreated(EventSourceId, alertRuleName, healthRiskNumber, numberOfCasesThreshold, distanceBetweenCasesInMeters, thresholdTimeframeInHours));
        }

        public void UpdateAlertRule(AlertRuleName alertRuleName, HealthRiskNumber healthRiskNumber, NumberOfCasesThreshold numberOfCasesThreshold, DistanceBetweenCasesInMeters distanceBetweenCasesInMeters, ThresholdTimeframeInHours thresholdTimeframeInHours)
        {
            Apply(new AlertRuleUpdated(EventSourceId, alertRuleName, healthRiskNumber, numberOfCasesThreshold, distanceBetweenCasesInMeters, thresholdTimeframeInHours));
        }

        public void DeleteAlertRule(EventSourceId id)
        {
            Apply(new AlertRuleDeleted(EventSourceId));
        }
    }
}