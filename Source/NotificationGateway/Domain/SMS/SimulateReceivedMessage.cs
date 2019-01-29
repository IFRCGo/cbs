using Dolittle.Commands;
using Concepts;
using Concepts.SMS;
using System;

namespace Domain.SMS
{
    public class SimulateReceivedMessage : ICommand
    {
        public MessageId Id { get; set; }
        public PhoneNumber Sender { get; set;}
        public Message Text { get; set; }
        public DateTimeOffset Received { get; set; }
    }
}
