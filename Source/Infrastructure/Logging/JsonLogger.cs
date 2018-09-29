/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Dolittle.Execution;
using Dolittle.Runtime.Commands.Coordination;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Infrastructure.Logging
{
    public class JsonLogger : ILogger
    {
        readonly string _category;
        readonly Func<string, LogLevel, bool> _filter;
        readonly Func<ExecutionContext> _getCurrentExecutionContext;

        public JsonLogger(Func<ExecutionContext> getCurrentExecutionContext, string source, string category, Func<string, LogLevel, bool> filter)
        {
            _category = category;
            _filter = filter;
            _getCurrentExecutionContext = getCurrentExecutionContext;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _filter == null || _filter(_category, logLevel);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;

            if (formatter == null) throw new ArgumentNullException(nameof(formatter));

            try
            {
                var level = "info";
                var writer = Console.Out;
                switch (logLevel)
                {
                    case LogLevel.Critical:
                        level = "fatal";
                        writer = Console.Error;
                        break;
                    case LogLevel.Error:
                        level = "error";
                        writer = Console.Error;
                        break;
                    case LogLevel.Warning:
                        level = "warn";
                        break;
                    case LogLevel.Information:
                        level = "info";
                        break;
                    case LogLevel.Debug:
                        level = "debug";
                        break;
                    case LogLevel.Trace:
                        level = "trace";
                        break;
                }

                var message = formatter(state, exception);
                var file = "[Unknown]";
                var line = 0;

                if (message.StartsWith("["))
                {
                    var endIndex = message.IndexOf(']');
                    if (endIndex > 0)
                    {
                        var fileAndLine = message.Substring(1, endIndex - 1);
                        var regex = new Regex(@"([\w.]+)\(([0-9]+)\)");
                        var match = regex.Match(fileAndLine);
                        if (match.Success)
                        {
                            file = match.Groups[1].Value;
                            int.TryParse(match.Groups[2].Value, out line);

                            message = message.Substring(endIndex + 1);
                            if (message.StartsWith("-")) message = message.Substring(1);
                        }
                    }
                }

                object content = state;

                if (state is IReadOnlyList<KeyValuePair<string, object>>)
                {
                    var keyValuePairs = state as IReadOnlyList<KeyValuePair<string, object>>;
                    var list = new List<KeyValuePair<string, object>>(keyValuePairs.Where(k =>
                        k.Key != "{OriginalFormat}"));
                    content = list.ToDictionary(x => x.Key, x => x.Value);
                }

                var executionContext = _getCurrentExecutionContext();

                var logMessage = new LogMessage
                {
                    Message = message,
                    Timestamp = DateTime.UtcNow,
                    Level = level,
                    Content = content,
                    Method = file,
                    Line = line,
                    CorrelationId = executionContext.CorrelationId,
                    StackTrace = exception?.StackTrace ?? string.Empty
                };


                var serialized = JsonConvert.SerializeObject(logMessage, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
                writer.WriteLine(serialized);
            }
            finally
            {
            }
        }
    }
}