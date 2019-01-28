using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.SMS.Gateways;

namespace Domain.SMS.Gateways
{
    public class SmsGatewayAggregate : AggregateRoot
    {
        public SmsGatewayAggregate(EventSourceId id) : base(id)
        {
        }

        public void RegisterSmsGateway(string name, string apiKey)
        {
            Apply(new SmsGatewayRegistered(EventSourceId, name, apiKey));
        }

        public void AssignPhoneNumberToSmsGateway(string phoneNumber)
        {
            Apply(new SmsGatewayNumberAssigned(EventSourceId, phoneNumber));
        }

        public void EnableSmsGateway()
        {
            Apply(new SmsGatewayEnabled(EventSourceId, true));
        }
    }
}
