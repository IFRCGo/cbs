/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Autofac;
using Dolittle.AspNetCore.Bootstrap;
using Dolittle.DependencyInversion.Autofac;
using Infrastructure.AspNet.ConnectionStrings;
using Infrastructure.Kafka.BoundedContexts;
using Infrastructure.TextMessaging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace Infrastructure.AspNet
{
    public class Startup
    {

        readonly ILoggerFactory _loggerFactory;
        readonly IHostingEnvironment _env;
        readonly IConfiguration _configuration;
        BootResult _bootResult;

        public Startup(ILoggerFactory loggerFactory, IHostingEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
            _loggerFactory = loggerFactory;

            loggerFactory.AddJson(Globals.BoundedContext.Name.AsString());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (_env.IsDevelopment())
            {
                services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" }); });
            }

            services
                .AddCors()
                .AddMvc();
            services.Configure<ConnectionStringsOptions>(_configuration);

            _bootResult = services.AddDolittle(_loggerFactory);
            ConfigureServicesCustom(services);
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddDolittle(_bootResult.Assemblies, _bootResult.Bindings);
            ConfigureContainerCustom(containerBuilder);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
            }
            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowCredentials());
            app.UseMvc();
            if (env.IsDevelopment()) app.UseSwagger();
            
            app.UseDolittle();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            BoundedContextListener.Start(app.ApplicationServices);
            TextMessageListener.Start(app.ApplicationServices);

            ConfigureCustom(app, env);

            // Keep last
            app.RunAsSinglePageApplication();
        }

        public virtual void ConfigureServicesCustom(IServiceCollection services)
        {
            services.AddReadModule();
        }

        public virtual void ConfigureContainerCustom(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddReadModule();
        }
        public virtual void ConfigureCustom(IApplicationBuilder application, IHostingEnvironment env) {}
    }
}