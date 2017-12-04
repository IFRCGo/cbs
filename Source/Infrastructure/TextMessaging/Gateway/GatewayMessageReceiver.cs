using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using doLittle.Logging;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Newtonsoft.Json;

namespace Infrastructure.TextMessaging.Gateway
{
    public class GatewayMessageReceiver
    {
        readonly ILogger _logger;
        readonly ITextMessageProcessors _processors;
        readonly MessageReceiver _receiver;

        public GatewayMessageReceiver(GatewaySettings settings, ITextMessageProcessors processors, ILogger logger)
        {
            _logger = logger;
            _processors = processors;

            var subscription = EntityNameHelper.FormatSubscriptionPath(settings.ListenToTopic, settings.ServiceName);
            _receiver = new MessageReceiver(settings.ServieBusConnectionString, subscription);
            _receiver.RegisterMessageHandler(NewMessagReceivedHandler, ExceptionReceivedHandler);

            _logger.Information($"Conneted SmsReciever to {settings.ServiceName}");
        }

        async Task NewMessagReceivedHandler(Message msg, CancellationToken cancellationToken)
        {
            try
            {
                if (!_processors.HasProcessors)
                {
                    await _receiver.DeferAsync(msg.SystemProperties.LockToken);
                    _logger.Warning("TextMessage listner is configured, but no ICanHandleTextMessage is registred-");
                    return;
                }

                var content = Encoding.UTF8.GetString(msg.Body);
                var sms = JsonConvert.DeserializeObject<TextMessage>(content);
                _logger.Information($"SMS recieved from {sms.OriginNumber} | '{sms.FullMessage}'");

                _processors.Process(sms);

                if (msg.SystemProperties.IsLockTokenSet && !msg.SystemProperties.IsReceived)
                {
                    _logger.Information(JsonConvert.SerializeObject(msg.SystemProperties, Formatting.Indented));
                    await _receiver.CompleteAsync(msg.SystemProperties.LockToken);
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed when processing IncommingSms: {ex.Message}");
                await _receiver.AbandonAsync(msg.SystemProperties.LockToken);
                throw;
            }
        }

        Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
        {
            _logger.Error($"SmsError: {arg.Exception.Message}");
            return Task.CompletedTask;
        }
    }
}
