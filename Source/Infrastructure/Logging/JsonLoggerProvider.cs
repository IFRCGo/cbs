using System;
using doLittle.Runtime.Commands;
using Microsoft.Extensions.Logging;

namespace Logging
{
    public class JsonLoggerProvider : ILoggerProvider
    {
        readonly Func<string, LogLevel, bool> _filter;
        readonly string _source;

        public JsonLoggerProvider(string source, Func<string, LogLevel, bool> filter)
        {
            _filter = filter;
            _source = source;
        }

        public ILogger CreateLogger(string categoryName)
        {
            ICommandContextManager commandContextManager = null;
            // Todo: Needs a proper correlation Id from real / current command context manager 
            // find a way to retrieve this
            commandContextManager = new NullCommandContextManager();

            return new JsonLogger(_source, categoryName, _filter, commandContextManager);
        }

        public void Dispose() { }
    }
}