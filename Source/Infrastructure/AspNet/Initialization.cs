using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using Autofac.Extensions.DependencyInjection;

namespace Infrastructure.AspNet
{
    public class Initialization
    {
        public static int BuildAndRun<TStartup>(string boundedContext, string[] args, Action<IWebHostBuilder> builderCallback = null, Action<LoggerConfiguration> loggerConfigurationCallback = null)
            where TStartup : class
        {
            var loggerConfiguration = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console();

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