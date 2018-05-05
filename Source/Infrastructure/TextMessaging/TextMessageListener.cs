using System;
using Dolittle.Applications;
using Dolittle.Serialization.Json;
using Dolittle.Logging;
using Infrastructure.Kafka;

namespace Infrastructure.TextMessaging
{
    public class TextMessageListener : ITextMessageListener
    {
        public static readonly Topic Topic = "incomingtextmessages";
        public static readonly ConsumerName Consumer = "IncomingTextMessages";
        readonly IConsumer _consumer;
        readonly ITextMessageProcessors _processors;
        readonly ISerializer _serializer;
        readonly BoundedContext _boundedContext;
        readonly ILogger _logger;

        readonly string _topicSuffix;

        public TextMessageListener(
            IConsumer consumer,
            ITextMessageProcessors processors,
            ISerializer serializer,
            BoundedContext boundedContext,
            ILogger logger)
        {
            _consumer = consumer;
            _processors = processors;
            _serializer = serializer;
            _boundedContext = boundedContext;
            _logger = logger;

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if( !string.IsNullOrEmpty(environment) && environment.ToLowerInvariant() == "development" ) {
                var user = Environment.GetEnvironmentVariable("USER");
                if( string.IsNullOrEmpty(user) ) user = Environment.GetEnvironmentVariable("user");
                if( string.IsNullOrEmpty(user) ) user = Environment.GetEnvironmentVariable("USERNAME");
                if( string.IsNullOrEmpty(user) ) user = Environment.GetEnvironmentVariable("username");
                if( string.IsNullOrEmpty(user) ) user = Guid.NewGuid().ToString();
                _topicSuffix = $"-{user}";
            }
        }

        public void Start()
        {
            if (_processors.HasProcessors) 
            {
                var consumerName = $"{Consumer}-{_boundedContext.Name}{_topicSuffix}";
                _logger.Information($"Setting up SMS consumer with name '{consumerName}'");
                _consumer.SubscribeTo(consumerName, Topic, MessageReceived);
            }
        }

        void MessageReceived(Topic topic, string json)
        {
            try
            {
                var message = _serializer.FromJson<TextMessage>(json);
                _logger.Information($"SMS received from '{message.OriginNumber}' - with message '{message.Message}'");
                _processors.Process(message);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Problems processing SMS");
            }
        }

        public static void Start(IServiceProvider serviceProvider)
        {
            var listener = serviceProvider.GetService(typeof(ITextMessageListener))as ITextMessageListener;
            listener.Start();
        }
    }
}