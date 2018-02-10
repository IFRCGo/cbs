using System;
using Microsoft.Extensions.Logging;
using Logging;

namespace Microsoft.Extensions.Logging
{
    public static class JsonLoggerExtensions
    {
        public static ILoggerFactory AddJson(this ILoggerFactory factory, string source, Func<string, LogLevel, bool> filter = null)
        {
            //factory.AddProvider(new JsonLoggerProvider(source, filter));
            return factory;
        }

        public static ILoggerFactory AddJson(this ILoggerFactory factory, string source)
        {
            return AddJson(
                factory,
                source,
                LogLevel.Information
            );
        }

        public static ILoggerFactory AddJson(this ILoggerFactory factory, string source, LogLevel minLevel)
        {
            return AddJson(
                factory,
                source,
                (_, logLevel) => logLevel >= minLevel);
        }
    }
}