/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Execution;
using Infrastructure.Logging;

namespace Microsoft.Extensions.Logging
{
    public static class JsonLoggerExtensions
    {
        public static ILoggerFactory AddJson(this ILoggerFactory factory, Func<ExecutionContext> getCurrentExecutionContext, string source,
            Func<string, LogLevel, bool> filter = null)
        {
            factory.AddProvider(new JsonLoggerProvider(getCurrentExecutionContext, source, filter));
            return factory;
        }

        public static ILoggerFactory AddJson(this ILoggerFactory factory, Func<ExecutionContext> getCurrentExecutionContext, string source)
        {
            return AddJson(
                factory,
                getCurrentExecutionContext,
                source,
                LogLevel.Information
            );
        }

        public static ILoggerFactory AddJson(this ILoggerFactory factory, Func<ExecutionContext> getCurrentExecutionContext, string source, LogLevel minLevel)
        {
            return AddJson(
                factory,
                getCurrentExecutionContext,
                source,
                (_, logLevel) => logLevel >= minLevel);
        }
    }
}