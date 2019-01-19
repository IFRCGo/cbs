using System;
using Dolittle.Events;
using Dolittle.Runtime.Events;

namespace Events.AlertRules
{
    public class AlertRuleCreated : IEvent
    {
        public Guid Id { get; }
        public string AlertRuleName { get; }
        public int HealthRiskId { get; }
        public int NumberOfCasesThreshold { get; }
        public int DistanceBetweenCasesInMeters { get; }

        public AlertRuleCreated(Guid id, string alertRuleName, int healthRiskId, int numberOfCasesThreshold, int distanceBetweenCasesInMeters)
        {
            Id = id;
            AlertRuleName = alertRuleName;
            HealthRiskId = healthRiskId;
            NumberOfCasesThreshold = numberOfCasesThreshold;
            DistanceBetweenCasesInMeters = distanceBetweenCasesInMeters;
        }
    }
}
