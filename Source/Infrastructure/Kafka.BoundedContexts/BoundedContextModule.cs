/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Autofac;

namespace Infrastructure.Kafka.BoundedContexts
{
    public class KafkaModule : Autofac.Module
    {
        const string KAFKA_BOUNDED_CONTEXT_TOPIC = "KAFKA_BOUNDED_CONTEXT_TOPIC";

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BoundedContextListener>().As<IBoundedContextListener>().SingleInstance();
            
            var environmentVariables = Environment.GetEnvironmentVariables();

            var committedEventStreamSenderConfiguration = new CommittedEventStreamSenderConfiguration(new Topic[0]);
            builder.RegisterInstance(committedEventStreamSenderConfiguration).As<CommittedEventStreamSenderConfiguration>();

            Topic topic = "";
            if( environmentVariables.Contains(KAFKA_BOUNDED_CONTEXT_TOPIC)) topic = (string)environmentVariables[KAFKA_BOUNDED_CONTEXT_TOPIC];
            var boundedContextListenerConfiguration = new BoundedContextListenerConfiguration(topic);
            builder.RegisterInstance(boundedContextListenerConfiguration).As<BoundedContextListenerConfiguration>();
        }
    }
}