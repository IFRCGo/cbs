/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Autofac;
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
        readonly string _swaggerPrefix;
        readonly string _swaggerBasePath;

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
                    c.SwaggerDoc("v2", new Info { Title = "VolunteerReporting API", Version = "v2" });
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
                        doc.BasePath = "/"+_swaggerBasePath;
                    });
                    c.RouteTemplate = _swaggerPrefix+"swagger/{documentName}/swagger.json";
                });
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/"+_swaggerPrefix+"swagger/v2/swagger.json", "VolunteerReporting API V2");
                    c.RoutePrefix = _swaggerPrefix+"swagger";
                });
            }

            // Todo: CORS this probably is a bit too lose.. 
            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowCredentials());

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();

            app.UseDolittle();
            app.RunAsSinglePageApplication();
        }
    }
}