using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using Autofac.Extensions.DependencyInjection;
using Serilog.Formatting.Json;
using Serilog.Core;
using Logging;

namespace Infrastructure.AspNet
{
    public class Initialization
    {
        public static int BuildAndRun<TStartup>(string boundedContext, string[] args, Action<IWebHostBuilder> builderCallback = null, Action<LoggerConfiguration> loggerConfigurationCallback = null)
            where TStartup : class
        {
            var loggerConfiguration = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("System", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.JsonConsole();

            if (loggerConfigurationCallback != null) loggerConfigurationCallback(loggerConfiguration);

            var logger = loggerConfiguration.CreateLogger();

            Log.Logger = logger;

            try
            {
                var builder = WebHost.CreateDefaultBuilder(args)
                    .ConfigureServices(services => services.AddAutofac())
                    .UseStartup<TStartup>()
                    .UseSerilog();

                if (builderCallback != null) builderCallback(builder);

                var host = builder.Build();
                host.Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}