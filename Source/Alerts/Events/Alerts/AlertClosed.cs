using Dolittle.Events;
using System;

namespace Events.Alerts
{
    public class AlertClosed : IEvent
    {
        public AlertClosed(int alertNumber) 
        {
            AlertNumber= alertNumber;
        }

        public int AlertNumber { get; }
    }
}
