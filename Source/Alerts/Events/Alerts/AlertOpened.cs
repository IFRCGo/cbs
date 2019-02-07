using System;
using Dolittle.Events;

namespace Events.Alerts
{
    public class AlertOpened : IEvent
    {
        public AlertOpened(Guid alertId, Guid alertRuleId, Guid[] reports)
        {
            AlertId = alertId;
            AlertRuleId = alertRuleId;
            Reports = reports;
        }

        public Guid AlertId { get; }
        public Guid AlertRuleId { get; }

        public Guid[] Reports { get; }
    }
}
