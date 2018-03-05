/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using doLittle.Logging;
using doLittle.Serialization.Json;

namespace Infrastructure.Kafka
{
    public class Consumer : IConsumer
    {
        readonly IConfiguration _configuration;
        readonly ILogger _logger;

        public Consumer(
            IConfiguration configuration,
            ISerializer serializer,
            ILogger logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void SubscribeTo(ConsumerName consumerName, Topic topic, EventReceived received)
        {
            _logger.Information($"Listening on topic '{topic}' from '{_configuration.ConnectionString}'");
            var consumer = new Confluent.Kafka.Consumer<Ignore, string>(_configuration.GetFor(consumerName), null, new StringDeserializer(Encoding.UTF8));
            consumer.Assign(new [] {  new TopicPartition(topic, 0)});
            consumer.OnMessage += (_, message)=>
            {
                try
                {
                    received(topic, message.Value);
                    consumer.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Couldn't handle received message");
                }
            };
            consumer.OnError += (_, message)=> _logger.Error(message.Reason);

            Task.Run(()=>
            {
                for (;;)consumer.Poll(TimeSpan.FromMilliseconds(50));
            });
        }
    }
}