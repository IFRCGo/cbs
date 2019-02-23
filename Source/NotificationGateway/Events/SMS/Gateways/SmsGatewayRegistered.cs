using System;
using Dolittle.Events;

namespace Events.SMS.Gateways
{
    public class SmsGatewayRegistered : IEvent
    {
        public SmsGatewayRegistered(
            Guid id,
            string name,
            string apiKey)
        {
            Id = id;
            Name = name;
            ApiKey = apiKey;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string ApiKey { get; }
    }
}
