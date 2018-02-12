using System;
using Autofac;

namespace Kafka
{
    public class KafkaModule : Autofac.Module
    {
        const string KAFKA_CONNECTIONSTRING = "KAFKA_CONNECTIONSTRING";

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BoundedContextListener>().As<IBoundedContextListener>().SingleInstance();
            
            var environmentVariables = Environment.GetEnvironmentVariables();
            var kafkaConnectionString = "52.178.92.69:9092";
            if (environmentVariables.Contains(KAFKA_CONNECTIONSTRING))kafkaConnectionString = (string)environmentVariables[KAFKA_CONNECTIONSTRING];
            
            // _.For<TopicMessageSettings>().Use(() => new TopicMessageSettings { Server = kafkaConnectionString }).SetLifecycleTo(Lifecycles.Singleton);
        }
    }
}