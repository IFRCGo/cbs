using System;
using Dolittle.Applications;
using Dolittle.Serialization.Json;
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

        public TextMessageListener(IConsumer consumer, ITextMessageProcessors processors, ISerializer serializer, BoundedContext boundedContext)
        {
            _consumer = consumer;
            _processors = processors;
            _serializer = serializer;
            _boundedContext = boundedContext;
        }

        public void Start()
        {
            if( _processors.HasProcessors )
                _consumer.SubscribeTo($"{Consumer}-{_boundedContext.Name}", Topic, MessageReceived);
            
        }

        void MessageReceived(Topic topic, string json)
        {
            var message = _serializer.FromJson<TextMessage>(json);
            _processors.Process(message);
        }

        public static void Start(IServiceProvider serviceProvider)
        {
            var listener = serviceProvider.GetService(typeof(ITextMessageListener)) as ITextMessageListener;
            listener.Start();
        }
    }
}