using System;
using Concepts.SMS;
using Concepts.SMS.Gateways;
using Dolittle.Commands;

namespace Domain.SMS.Gateways
{
    public class ReceiveMessageFromSMSGateway : ICommand
    {
        public Concepts.MessageId Id { get; set; }
        public PhoneNumber Sender { get; set;}
        public Message Text { get; set; }
        public DateTimeOffset Received { get; set; }
        public ApiKey ApiKey { get; set; }
        public MessageId GatewayId { get; set; }
        public OID OID { get; set; }
        public ModemNumber ModemNumber { get; set; }
    }
}
