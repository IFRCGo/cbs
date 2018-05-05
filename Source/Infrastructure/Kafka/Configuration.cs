/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Dolittle.Logging;

namespace Infrastructure.Kafka
{

    public class Configuration : IConfiguration
    {
        readonly ILogger _logger;

        public Configuration(KafkaConnectionString connectionString, ILogger logger)
        {
            ConnectionString = connectionString;
            _logger = logger;
        }

        public KafkaConnectionString ConnectionString { get; }

        public Dictionary<string, object> GetFor(string consumer)
        {
            _logger.Information($"Getting Kafka configuration for {consumer} - for Kafka running at {ConnectionString}");

            var config = new Dictionary<string, object>
                { { "bootstrap.servers", ConnectionString },
                    { "group.id", consumer },
                    { "enable.auto.commit", false },
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