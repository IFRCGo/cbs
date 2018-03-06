/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Linq;
using Autofac;

namespace Infrastructure.Kafka.BoundedContexts
{
    public class KafkaModule : Autofac.Module
    {
        const string KAFKA_BOUNDED_CONTEXT_TOPIC = "KAFKA_BOUNDED_CONTEXT_TOPIC";
        const string KAFKA_BOUNDED_CONTEXT_SEND_TOPICS = "KAFKA_BOUNDED_CONTEXT_SEND_TOPICS";

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BoundedContextListener>().As<IBoundedContextListener>().SingleInstance();
            
            var environmentVariables = Environment.GetEnvironmentVariables();

            var kafkaSendTopics = new string[0];
            if (environmentVariables.Contains(KAFKA_BOUNDED_CONTEXT_SEND_TOPICS)) kafkaSendTopics = ((string)environmentVariables[KAFKA_BOUNDED_CONTEXT_SEND_TOPICS]).Split(';');

            var committedEventStreamSenderConfiguration = new CommittedEventStreamSenderConfiguration(kafkaSendTopics.Select(_ => (Topic)_));
            builder.RegisterInstance(committedEventStreamSenderConfiguration).As<CommittedEventStreamSenderConfiguration>();

            Topic topic = "";
            if( environmentVariables.Contains(KAFKA_BOUNDED_CONTEXT_TOPIC)) topic = (string)environmentVariables[KAFKA_BOUNDED_CONTEXT_TOPIC];
            var boundedContextListenerConfiguration = new BoundedContextListenerConfiguration(topic);
            builder.RegisterInstance(boundedContextListenerConfiguration).As<BoundedContextListenerConfiguration>();
        }
    }
}