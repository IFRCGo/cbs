/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Autofac;

namespace Kafka
{
    public class KafkaModule : Autofac.Module
    {
        const string KAFKA_CONNECTIONSTRING = "KAFKA_CONNECTIONSTRING";

        protected override void Load(ContainerBuilder builder)
        {
            var environmentVariables = Environment.GetEnvironmentVariables();
            var kafkaConnectionString = "52.178.92.69:9092";
            if (environmentVariables.Contains(KAFKA_CONNECTIONSTRING))kafkaConnectionString = (string)environmentVariables[KAFKA_CONNECTIONSTRING];
        }
    }
}