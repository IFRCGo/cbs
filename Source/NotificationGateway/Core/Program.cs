using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //while(!System.Diagnostics.Debugger.IsAttached) {System.Threading.Thread.Sleep(100);};
            CreateWebHostBuilder(args).Build().Run();
        }

        static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .ConfigureLogging(builder => {
                    builder.AddApplicationInsights(Environment.GetEnvironmentVariable("ASPNETCORE_APPINSIGHTS_INSTRUMENTATIONKEY"));
                    builder.AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>
                                    ("NotificationGateway.Program", LogLevel.Trace);
                    builder.AddFilter<Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider>
                                    ("NotificationGateway.Startup", LogLevel.Trace);
                })             
                .ConfigureServices(services => services.AddAutofac())
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>();
    }
}
