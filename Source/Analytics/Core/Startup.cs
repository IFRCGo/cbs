using System;
using Autofac;
using Dolittle.AspNetCore.Bootstrap;
using Dolittle.AspNetCore.Swagger.Debugging;
using Dolittle.Booting;
using Dolittle.DependencyInversion.Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace Core
{
    public partial class Startup
    {
        readonly IHostingEnvironment _hostingEnvironment;
        readonly ILoggerFactory _loggerFactory;
        BootloaderResult _bootResult;

        public Startup(IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory)
        {
            _hostingEnvironment = hostingEnvironment;
            _loggerFactory = loggerFactory;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (_hostingEnvironment.IsDevelopment())
            {
                services.AddDolittleSwagger();
            }
            // services.AddSecurity(_hostingEnvironment, "/analytics");
            services.AddMvc();

            _bootResult = services.AddDolittle(_loggerFactory);
        }


        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddDolittle(_bootResult.Assemblies, _bootResult.Bindings);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // app.UseSecurity(env, "/analytics");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDolittleSwagger();
            }

            app.UsePathBase("/analytics");

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();

            app.UseDolittle();
            app.RunAsSinglePageApplication();
        }

    }
}