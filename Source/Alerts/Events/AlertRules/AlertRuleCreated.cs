using System;
using Dolittle.Events;

namespace Events.AlertRules
{
    public class AlertRuleCreated : IEvent
    {
        public Guid Id { get; }

        public AlertRuleCreated(Guid id)
        {
            Id = id;
        }
    }
}
