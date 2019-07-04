using Dolittle.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Events.Alerts
{
    public class ReportAddedToAlert : IEvent
    {
        public ReportAddedToAlert(Guid reportId, Guid alertId)
        {
            ReportId = reportId;
            AlertId = alertId;
        }
        public Guid ReportId { get; }
        public Guid AlertId { get; }
    }
}
