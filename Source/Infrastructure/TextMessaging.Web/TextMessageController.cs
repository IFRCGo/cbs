using doLittle.Serialization.Json;
using Infrastructure.Kafka;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.TextMessaging.Web
{
    [Route("/api/textmessages")]
    public class TextMessageController
    {
        readonly IPublisher _publisher;
        readonly ISerializer _serializer;

        public TextMessageController(IPublisher publisher, ISerializer serializer)
        {
            _serializer = serializer;
            _publisher = publisher;
        }

        [HttpPost]
        public void Post([FromBody] TextMessage message)
        {
            var messageAsJson = _serializer.ToJson(message);
            _publisher.Publish(TextMessageListener.Topic, messageAsJson);
        }
    }
}