using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Newtonsoft.Json;
using doLittle.Logging;

namespace Infrastructure.TextMessaging.Gateway
{
    /// <summary>
    /// 
    /// </summary>
    internal class GatewayMessageSenderLoopback : ISendSms
    {
        readonly ILogger _logger;
        readonly MessageSender _sender;

        public GatewayMessageSenderLoopback(GatewaySettings settings, ILogger logger)
        {
            _logger = logger;
            _sender = new MessageSender(settings.ServiceName, "incomming", new RetryExponential(TimeSpan.FromSeconds(3), TimeSpan.FromMinutes(3), 25));
            _logger.Information($"Conneted SmsSender to internal Loopback Adapter");
        }

        public Task SendAsync(string receiverCountryCode, string number, string message)
        {
            return SendAsync(new OutgoingTextMessage()
            {
                ReceiverCountryCode = receiverCountryCode,
                Message = message,
                Number = number
            });
        }

        public async Task SendAsync(OutgoingTextMessage sms)
        {

            if (string.IsNullOrEmpty(sms.Number))
                throw new Exception("Sms Number is required");
            if (string.IsNullOrEmpty(sms.ReceiverCountryCode))
                throw new Exception("ReceiverCountryCode is required");

            var loopSms = new TextMessage
            {
                FullMessage = sms.Message,
                Message = sms.Message,
                OriginNumber = sms.Number,
            };

            var msg = new Message
            {
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(loopSms, Formatting.Indented)),
                MessageId = Guid.NewGuid().ToString("n"),
            };
            msg.UserProperties.Add("SenderSource", "Internal");

            _logger.Information($"Sending sms: {sms.Number}| {sms.Message}");
            await _sender.SendAsync(msg);
        }
    }
}