using System;
using Dolittle.Events;

namespace Events.AlertRules
{
    public class AlertRuleDeleted : IEvent
    {
        public AlertRuleDeleted(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
