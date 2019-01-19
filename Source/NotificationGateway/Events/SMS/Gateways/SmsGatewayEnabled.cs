using System;
using Dolittle.Events;

namespace Events.SMS.Gateways
{
    public class SmsGatewayEnabled : IEvent
    {
        public SmsGatewayEnabled(Guid id, bool enabled)
        {
            Id = id;
            Enabled = enabled;
        }

        public Guid Id { get; }
        public bool Enabled { get;}
    }
}
