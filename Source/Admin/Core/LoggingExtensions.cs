using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;

namespace Core
{
    public static class LoggingExtensions
    {
        public static IWebHostBuilder ConfigureApplicationInsightsLogging(this IWebHostBuilder builder)
        {
            var instrumentationKey = Environment.GetEnvironmentVariable("ASPNETCORE_APPINSIGHTS_INSTRUMENTATIONKEY");

            if (!String.IsNullOrEmpty(instrumentationKey))
            {
                builder.ConfigureLogging(_ => {
                    _.AddApplicationInsights(instrumentationKey);
                    _.AddFilter<ApplicationInsightsLoggerProvider>("Admin.Program", LogLevel.Trace);
                    _.AddFilter<ApplicationInsightsLoggerProvider>("Admin.Startup", LogLevel.Trace);
                });
            }
            
            return builder;
        }
    }
}