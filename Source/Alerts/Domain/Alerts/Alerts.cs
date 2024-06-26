using System;
using System.Collections.Generic;
using System.Linq;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.Alerts;

namespace Domain.Alerts
{
    public class Alerts : AggregateRoot
    {
        public static EventSourceId SingletonId = Guid.Parse("814d9996-ac81-42ec-8375-a389f893aec7");

        uint numberOfAlertsOpened = 0;
        
        public Alerts(EventSourceId id) : base(id)
        {
        }

        public void OpenAlert(Guid alertId, Guid alertRuleId, IReadOnlyCollection<Guid> cases)
        {
            Apply(new AlertOpened(alertId, alertRuleId, numberOfAlertsOpened+1, cases.ToArray()));
        }

        public void AddReportToAlert(Guid reportId, Guid alertId)
        {
            Apply(new ReportAddedToAlert(reportId, alertId));
        }

        private void On(AlertOpened @event)
        {
            numberOfAlertsOpened++;
        }

        public void CloseAlert(int alertNumber) 
        {
            Apply(new AlertClosed(alertNumber));
        }
    }
}
