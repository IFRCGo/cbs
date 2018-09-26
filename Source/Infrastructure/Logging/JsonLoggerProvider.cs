/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Execution;
using Dolittle.Runtime.Commands;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Logging
{
    public class JsonLoggerProvider : ILoggerProvider
    {
        readonly Func<string, LogLevel, bool> _filter;
        readonly string _source;
        readonly Func<ExecutionContext> _getCurrentExecutionContext;

        public JsonLoggerProvider(Func<ExecutionContext> getCurrentExecutionContext,string source, Func<string, LogLevel, bool> filter)
        {
            _filter = filter;
            _source = source;
            _getCurrentExecutionContext = getCurrentExecutionContext;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new JsonLogger(_getCurrentExecutionContext, _source, categoryName, _filter);
        }

        public void Dispose()
        {
        }
    }

}