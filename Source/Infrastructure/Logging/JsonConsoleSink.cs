/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog.Core;
using Serilog.Events;

namespace Infrastructure.Logging
{
    public class JsonConsoleSink : ILogEventSink
    {
        public void Emit(LogEvent logEvent)
        {
            var level = "info";
            var writer = Console.Out;
            switch (logEvent.Level)
            {
                case LogEventLevel.Fatal:
                    level = "fatal";
                    writer = Console.Error;
                    break;
                case LogEventLevel.Error:
                    level = "error";
                    writer = Console.Error;
                    break;
                case LogEventLevel.Warning:
                    level = "warn";
                    break;
                case LogEventLevel.Information:
                    level = "info";
                    break;
                case LogEventLevel.Debug:
                    level = "debug";
                    break;
                case LogEventLevel.Verbose:
                    level = "verbose";
                    break;
            }

            var logMessage = new LogMessage
            {
                Message = logEvent.RenderMessage(),
                Timestamp = logEvent.Timestamp,
                Level = level,
                Content = logEvent.Properties,
                Method = "[Unknown]",
                Line = 0,
                CorrelationId = Guid.Empty
            };

            var serialized = JsonConvert.SerializeObject(logMessage, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            writer.WriteLine(serialized);
        }
    }
}