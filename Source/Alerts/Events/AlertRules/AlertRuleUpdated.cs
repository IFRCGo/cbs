using System;
using Dolittle.Events;

namespace Events.AlertRules
{
    public class AlertRuleUpdated : IEvent
    {
        public Guid Id { get; }
        public string AlertRuleName { get; }
        public int HealthRiskId { get; }
        public int NumberOfCasesThreshold { get; }
        public int DistanceBetweenCasesInMeters { get; }

        public AlertRuleUpdated(Guid id, string alertRuleName, int healthRiskId, int numberOfCasesThreshold, int distanceBetweenCasesInMeters)
        {
            Id = id;
            AlertRuleName = alertRuleName;
            HealthRiskId = healthRiskId;
            NumberOfCasesThreshold = numberOfCasesThreshold;
            DistanceBetweenCasesInMeters = distanceBetweenCasesInMeters;
        }

    }
}
