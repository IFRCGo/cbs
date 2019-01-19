using Concepts;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events;
using Events.AlertRules;

namespace Domain.AlertRules
{
    public class AlertRule : AggregateRoot
    {
        public AlertRule(EventSourceId id) : base(id)
        {
        }

        public void CreateAlertRule(AlertRuleName alertRuleName, HealthRiskId healthRiskId, NumberOfCasesThreshold numberOfCasesThreshold, DistanceBetweenCasesInMeters distanceBetweenCasesInMeters)
        {
            Apply(new AlertRuleCreated(EventSourceId, alertRuleName, healthRiskId, numberOfCasesThreshold, distanceBetweenCasesInMeters));
        }

        public void UpdateAlertRule(AlertRuleName alertRuleName, HealthRiskId healthRiskId, NumberOfCasesThreshold numberOfCasesThreshold, DistanceBetweenCasesInMeters distanceBetweenCasesInMeters)
        {
            Apply(new AlertRuleUpdated(EventSourceId, alertRuleName, healthRiskId, numberOfCasesThreshold, distanceBetweenCasesInMeters));
        }

        public void DeleteAlertRule(EventSourceId id)
        {
            Apply(new AlertRuleDeleted(EventSourceId));
        }
    }
}