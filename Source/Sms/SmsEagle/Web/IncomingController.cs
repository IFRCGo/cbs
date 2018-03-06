using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using doLittle.Logging;
using doLittle.Serialization.Json;
using Infrastructure.Kafka;
using Infrastructure.TextMessaging;
using Microsoft.AspNetCore.Mvc;

namespace Web
{
    [Route("incoming")]
    public class IncomingController : Controller
    {
        private readonly IPublisher _publisher;
        private readonly ISerializer _serializer;
        private readonly ILogger _logger;

        public IncomingController(
            IPublisher publisher,
            ISerializer serializer, 
            ILogger logger)
        {
            _serializer = serializer;
            _publisher = publisher;
            _logger = logger;
        }

        [HttpPost]
        public void Receive([FromForm] SMS sms)
        {
            var incomingTextMessage = new TextMessage
            {
                Id = Guid.NewGuid(),
                Sent = DateTimeOffset.ParseExact(sms.Timestamp,"yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture),
                OriginNumber = sms.Sender,
                Message = sms.Text,
                FullMessage = sms.Text,
                ReceivedAtGatewayNumber = sms.ModemNo,
            };

            var incomingTextMessageAsJson = _serializer.ToJson(incomingTextMessage);
            _publisher.Publish(TextMessageListener.Topic, incomingTextMessageAsJson);
            _logger.Information(incomingTextMessageAsJson);
        }
    }
}