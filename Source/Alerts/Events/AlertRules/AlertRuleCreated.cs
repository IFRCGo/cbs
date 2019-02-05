/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.AlertRules
{
    public class AlertRuleCreated : IEvent
    {
        public Guid Id { get; }
        public string AlertRuleName { get; }
        public int HealthRiskId { get; }
        public int NumberOfCasesThreshold { get; }
        public int DistanceBetweenCasesInMeters { get; }
        public int ThresholdTimeframeInHours { get; }

        public AlertRuleCreated(Guid id, string alertRuleName, int healthRiskId, int numberOfCasesThreshold,
            int distanceBetweenCasesInMeters, int thresholdTimeframeInHours)
        {
            Id = id;
            AlertRuleName = alertRuleName;
            HealthRiskId = healthRiskId;
            NumberOfCasesThreshold = numberOfCasesThreshold;
            DistanceBetweenCasesInMeters = distanceBetweenCasesInMeters;
            ThresholdTimeframeInHours = thresholdTimeframeInHours;
        }
    }
}
