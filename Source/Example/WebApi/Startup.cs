using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebApi
{
    public class Startup : Infrastructure.AspNet.Startup
    {
        public Startup(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCommon();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCommon(env);
        }
    }
}