using System;
using Concepts;
using Concepts.SMS;
using Dolittle.ReadModels;

namespace Read.SMS
{
    public class ReceivedMessage : IReadModel
    {
        public MessageId Id { get; set; }
        public PhoneNumber Sender { get; set;}
        public Message Text { get; set; }
        public DateTimeOffset Received { get; set; }
    }
}
