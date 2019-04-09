using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.NotificationGateway.Reporting.SMS
{
    [Artifact("191714a9-1c30-4509-8fdc-7a84a0544fc1")]
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
