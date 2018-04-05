using Dolittle.Serialization.Json;
using Infrastructure.Kafka;

namespace Infrastructure.TextMessaging
{
    public class TextMessageSender : ITextMessageSender
    {
        public static readonly Topic Topic = "outgoingtextmessages";
        readonly IPublisher _publisher;
        readonly ISerializer _serializer;

        public TextMessageSender(IPublisher publisher, ISerializer serializer)
        {
            _publisher = publisher;
            _serializer = serializer;
        }

        public void Send(OutgoingTextMessage message)
        {
            var messageAsJson = _serializer.ToJson(message);
            _publisher.Publish(Topic, messageAsJson);
        }
    }
}