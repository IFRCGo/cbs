using System;
using Dolittle.Events;

namespace Events.SMS.Gateways
{
    public class SmsGatewayNumberAssigned : IEvent
    {
        public Guid Id { get; }
        public string PhoneNumber { get; }

        public SmsGatewayNumberAssigned(Guid id, string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
            this.Id = id;
        }
    }
}
