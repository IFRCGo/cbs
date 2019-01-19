using System;
using Dolittle.Events;

namespace Events.AlertRules
{
    public class AlertRuleUpdated : IEvent
    {
        public AlertRuleUpdated(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
