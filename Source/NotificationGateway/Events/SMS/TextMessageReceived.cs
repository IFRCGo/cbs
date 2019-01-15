using System;
using Dolittle.Events;

namespace Events.SMS
{
    public class TextMessageReceived : IEvent
    {
        public TextMessageReceived(Guid id, string sender, string text, DateTimeOffset received)
        {
            Id = id;
            Sender = sender;
            Text = text;
            Received = received;
        }

        public Guid Id { get; }
        public string Sender { get; }
        public string Text { get; }
        public DateTimeOffset Received { get; }
    }
}
