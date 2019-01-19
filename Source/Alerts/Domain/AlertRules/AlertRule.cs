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

        public void CreateAlertRule()
        {
            Apply(new AlertRuleCreated(EventSourceId));
        }

        public void UpdateAlertRule()
        {
            Apply(new AlertRuleUpdated(EventSourceId));
        }

        public void DeleteAlertRule()
        {
            Apply(new AlertRuleDeleted(EventSourceId));
        }
    }
}