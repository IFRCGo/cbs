/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using doLittle.Logging;

namespace Infrastructure.Kafka
{
    /// <summary>
    /// Represents an implementation of <see cref="IPublisher"/>
    /// </summary>
    public class Publisher : IPublisher, IDisposable
    {
        readonly Producer<Null, string> _producer;

        /// <summary>
        /// Initializes a new instance of <see cref="Publisher"/>
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/> used</param>
        /// <param name="logger"><see cref="ILogger"/> used for logging</param>
        public Publisher(IConfiguration configuration, ILogger logger)
        {
            _producer = new Producer<Null, string>(configuration.GetForPublisher(), null, new StringSerializer(Encoding.UTF8));
            _producer.OnError += (sender, error) =>
            {
                logger.Error(error.Reason);
            };
        }

        ~Publisher()
        {
            Dispose();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _producer.Flush(TimeSpan.FromSeconds(5));
        }

        /// <inheritdoc/>
        public void Publish(Topic topic, string json)
        {
            _producer.ProduceAsync(topic, null, json);
        }
    }
}