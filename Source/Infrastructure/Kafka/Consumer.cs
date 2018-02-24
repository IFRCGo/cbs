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

namespace Kafka
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

        public void SubscribeTo(Topic topic, EventReceived received)
        {
            _logger.Information($"Listening on topic '{topic}' from '{_configuration.ConnectionString}'");
            var consumer = new Confluent.Kafka.Consumer<Ignore, string>(_configuration.GetFor(topic), null, new StringDeserializer(Encoding.UTF8));
            consumer.Assign(new [] {  new TopicPartition(topic, 0)});
            consumer.OnMessage += (_, message)=> received(topic, message.Value);

            Task.Run(()=>
            {
                for (;;)consumer.Poll(TimeSpan.FromMilliseconds(50));
            });
        }
    }
}