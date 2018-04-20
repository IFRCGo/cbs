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
            var dateTime = DateTime.ParseExact(sms.Timestamp, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
            var dateTimeOffset = new DateTimeOffset(dateTime);
            try
            { 
                var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Oslo");
                
                var offset = timeZone.GetUtcOffset(dateTime);
                dateTime = dateTime.Subtract(offset);
                dateTimeOffset = new DateTimeOffset(dateTime, offset);
            } catch {}

            var incomingTextMessage = new TextMessage
            {
                Id = Guid.NewGuid(),
                Sent = dateTimeOffset,
                OriginNumber = sms.Sender,
                Message = sms.Text,
                FullMessage = sms.Text,
                ReceivedAtGatewayNumber = sms.ModemNo,
            };
          
            var incomingTextMessageAsJson = _serializer.ToJson(incomingTextMessage);
            _publisher.Publish(TextMessageListener.Topic, incomingTextMessageAsJson);
            _logger.Information(incomingTextMessageAsJson);
        }

        [HttpPost ("/smssync")]
        public void MessageFromSMSSync([FromForm] SMSSync sms){
        
            var dateTime = DateTime.ParseExact(sms.Sent_timestamp, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
            var dateTimeOffset = new DateTimeOffset(dateTime);
            try
            { 
                var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Oslo");
                
                var offset = timeZone.GetUtcOffset(dateTime);
                dateTime = dateTime.Subtract(offset);
                dateTimeOffset = new DateTimeOffset(dateTime, offset);
            } catch {}

             var incomingTextMessage = new TextMessage
            {
                Id = Guid.NewGuid(),
                
                Sent = dateTimeOffset,
                OriginNumber = sms.From,
                Message = sms.Message,
                FullMessage = sms.Message,
                ReceivedAtGatewayNumber = sms.device_id,
            };       

            var incomingTextMessageAsJson = _serializer.ToJson(incomingTextMessage);
            _publisher.Publish(TextMessageListener.Topic, incomingTextMessageAsJson);
            _logger.Information(incomingTextMessageAsJson);


        }
    }
}