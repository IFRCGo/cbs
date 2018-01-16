using Serilog;
using Serilog.Configuration;
using Serilog.Events;

namespace Logging
{
    public static class SerilogConfigurationExtensions
    {
        public static LoggerConfiguration JsonConsole(this LoggerSinkConfiguration sinkConfiguration, LogEventLevel restrictedToMinimumLevel = LogEventLevel.Verbose)
        {
            return sinkConfiguration.Sink(new JsonConsoleSink(), restrictedToMinimumLevel);
        }
    }

}