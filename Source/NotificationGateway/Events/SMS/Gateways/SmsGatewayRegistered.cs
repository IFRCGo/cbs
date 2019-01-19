using System;
using Dolittle.Events;

namespace Events.SMS.Gateways
{
    public class SmsGatewayRegistered : IEvent
    {
        public SmsGatewayRegistered(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name {get;}
    }
}
