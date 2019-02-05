using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.NotificationGateway.Reporting.SMS
{
    [Artifact("573d4609-fa75-4c2f-8d7c-f7cf7da3de53")]
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
