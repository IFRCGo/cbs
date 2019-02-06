using System;
using Autofac;
using Dolittle.AspNetCore.Bootstrap;
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
        private readonly string _swaggerPrefix;
        private readonly string _swaggerBasePath;

        public Startup(IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory)
        {
            _hostingEnvironment = hostingEnvironment;
            _loggerFactory = loggerFactory;
            _swaggerPrefix = Environment.GetEnvironmentVariable("SWAGGER_PREFIX") ?? "";
            _swaggerBasePath = Environment.GetEnvironmentVariable("SWAGGER_BASE_PATH") ?? "";
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (_hostingEnvironment.IsDevelopment())
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "Alerts API", Version = "v1" });
                });
            }
            services.AddMvc();

            _bootResult = services.AddDolittle(_loggerFactory);
        }


        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddDolittle(_bootResult.Assemblies, _bootResult.Bindings);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(c => {
                    c.PreSerializeFilters.Add((doc, req) => {
                        doc.BasePath = "/" + _swaggerBasePath;
                    });
                    c.RouteTemplate = _swaggerPrefix + "swagger/{documentName}/swagger.json";
                });
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/" + _swaggerPrefix + "swagger/v1/swagger.json", "Alerts API V1");
                    c.RoutePrefix = _swaggerPrefix + "swagger";
                });

                app.UseCors(c => {
                    c.AllowAnyHeader();
                    c.AllowAnyMethod();
                    c.AllowCredentials();
                    c.AllowAnyOrigin();
                });
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();


            app.UseDolittle();
            app.RunAsSinglePageApplication();
        }

    }
}