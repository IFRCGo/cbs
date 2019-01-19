using Concepts.SMS;
using Concepts.SMS.Gateways;
using Dolittle.Commands;

namespace Domain.SMS.Gateways
{
    public class AssignPhoneNumberToSmsGateway : ICommand
    {
        public SmsGatewayId SmsGatewayId {get; set;}
        public PhoneNumber PhoneNumber {get; set;}
    }
}
