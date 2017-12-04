using System;
using System.Text;
using System.Threading.Tasks;
using doLittle.Logging;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Newtonsoft.Json;

namespace Infrastructure.TextMessaging.Gateway
{
    internal class GatewayMessageSender : ISendSms
    {
        private readonly GatewaySettings _settings;
        private readonly ILogger _logger;
        private readonly MessageSender _sender;

        public GatewayMessageSender(GatewaySettings settings, ILogger logger)
        {
            _settings = settings;
            _logger = logger;
            var retryPolicy = new RetryExponential(TimeSpan.FromSeconds(3), TimeSpan.FromMinutes(3), 25);
            _sender = new MessageSender(settings.ServieBusConnectionString, settings.SendQueueName, retryPolicy);
            _logger.Information($"Conneted SmsSender '{settings.ServiceName}' to outgoing queue: '{settings.SendQueueName}' ");
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

        public Task SendAsync(OutgoingTextMessage sms)
        {

            if (string.IsNullOrEmpty(sms.Number))
                throw new Exception("Sms Number is required");
            if (string.IsNullOrEmpty(sms.ReceiverCountryCode))
                throw new Exception("ReceiverCountryCode is required");

            var msg = new Message
            {
                Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(sms, Formatting.Indented)),
                MessageId = Guid.NewGuid().ToString("n"),
            };
            msg.UserProperties.Add("SenderSource", _settings.ServiceName);
            // msg.UserProperties.Add(nameof(Internals.BoundedContext), Internals.BoundedContext);

            _logger.Information($"Sending sms: {sms.Number}| {sms.Message}");
            return _sender.SendAsync(msg);
        }
    }
}
