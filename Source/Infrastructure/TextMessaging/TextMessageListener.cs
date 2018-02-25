using System;
using doLittle.Serialization.Json;
using Infrastructure.Kafka;

namespace Infrastructure.TextMessaging
{
    public class TextMessageListener : ITextMessageListener
    {
        public static readonly Topic Topic = "incomingtextmessages";
        readonly IConsumer _consumer;
        readonly ITextMessageProcessors _processors;
        readonly ISerializer _serializer;

        public TextMessageListener(IConsumer consumer, ITextMessageProcessors processors, ISerializer serializer)
        {
            _consumer = consumer;
            _processors = processors;
            _serializer = serializer;
        }

        public void Start()
        {
            if( _processors.HasProcessors )
                _consumer.SubscribeTo(Topic, MessageReceived);
            
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