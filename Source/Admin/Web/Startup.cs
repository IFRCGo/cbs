using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Web
{
    public class Startup : Infrastructure.AspNet.Startup
    {
        public Startup(
            ILoggerFactory loggerFactory, 
            IHostingEnvironment env, 
            IConfiguration configuration) : base(loggerFactory, env, configuration)
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