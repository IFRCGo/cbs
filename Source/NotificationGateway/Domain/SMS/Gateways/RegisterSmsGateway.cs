using Concepts.SMS.Gateways;
using Dolittle.Commands;

namespace Domain.SMS.Gateways
{
    public class RegisterSmsGateway : ICommand
    {
        public SmsGatewayId SmsGatewayId {get; set;}
        public Name Name {get; set;}
    }
}
