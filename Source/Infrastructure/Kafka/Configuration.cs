/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;

namespace Infrastructure.Kafka
{

    public class Configuration : IConfiguration
    {
        public Configuration(KafkaConnectionString connectionString)
        {
            ConnectionString = connectionString;
        }

        public KafkaConnectionString ConnectionString { get; }

        public Dictionary<string, object> GetFor(string consumer)
        {
            var config = new Dictionary<string, object>
                { { "bootstrap.servers", ConnectionString },
                    { "group.id", consumer },
                    { "enable.auto.commit", true },
                    { "auto.commit.interval.ms", 1000 },
                    {
                    "default.topic.config",
                    new Dictionary<string, object>()
                    { { "auto.offset.reset", "smallest" }
                    }
                    }
                };

            return config;
        }

        public Dictionary<string, object> GetForPublisher()
        {
            return GetFor("Publisher");
        }
    }
}