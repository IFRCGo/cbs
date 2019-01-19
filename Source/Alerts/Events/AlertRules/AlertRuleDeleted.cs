using System;
using Dolittle.Events;

namespace Events.AlertRules
{
    public class AlertRuleDeleted : IEvent
    {
        public Guid AlertRuleId { get; }

        public AlertRuleDeleted(Guid alertRuleId)
        {
            AlertRuleId = alertRuleId;
        }


    }
}
