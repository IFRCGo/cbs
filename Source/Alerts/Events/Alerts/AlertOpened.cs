using System;
using Dolittle.Events;

namespace Events.Alerts
{
    public class AlertOpened : IEvent
    {
        public AlertOpened(Guid alertId, Guid alertRuleId, Guid[] cases)
        {
            AlertId = alertId;
            AlertRuleId = alertRuleId;
            Cases = cases;
        }

        public Guid AlertId { get; }
        public Guid AlertRuleId { get; }

        public Guid[] Cases { get; }
    }
}
