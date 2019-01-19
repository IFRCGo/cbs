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
        public Alerts(EventSourceId id) : base(id)
        { 
        }

        public void OpenAlert(Guid alertId, Guid alertRuleId, IReadOnlyCollection<Guid> cases)
        {
            Apply(
                new AlertOpened(alertId, alertRuleId, cases.ToArray()));
        }
    }
}
