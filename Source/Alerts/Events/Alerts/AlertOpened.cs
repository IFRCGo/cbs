using System;
using Dolittle.Events;

namespace Events.Alerts
{
    public class AlertOpened : IEvent
    {
        public AlertOpened(Guid alertId, Guid alertRuleId, uint alertNumber, Guid[] reports)
        {
            AlertId = alertId;
            AlertRuleId = alertRuleId;
            AlertNumber = alertNumber;
            Reports = reports;
        }

        public Guid AlertId { get; }
        public Guid AlertRuleId { get; }
        public uint AlertNumber { get; }
        public Guid[] Reports { get; }
    }
}
