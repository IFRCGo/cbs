/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.IO;
using System.Threading.Tasks;
using Autofac;
using Dolittle.DependencyInversion.Autofac;
using Infrastructure.AspNet.ConnectionStrings;
using Infrastructure.Kafka.BoundedContexts;
using Infrastructure.TextMessaging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders.Physical;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace Infrastructure.AspNet
{
    public class Startup
    {
        readonly IHostingEnvironment _env;
        readonly IConfiguration _configuration;
        BootResult _bootResult;
        

        public Startup(ILoggerFactory loggerFactory, IHostingEnvironment env, IConfiguration configuration)
        {
            _configuration = configuration;
            _env = env;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            if( _env.IsDevelopment() )
            {
                services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "My API", Version = "v1"}); });
            }
            
            services
                .AddCors()
                .AddMvc();
            ;
            services.Configure<ConnectionStringsOptions>(_configuration);


            _bootResult = services.AddDolittle();
            
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
            app.UseSwagger();


            app.UseDefaultFiles();
            app.UseStaticFiles();

            //BoundedContextListener.Start(app.ApplicationServices);
            //TextMessageListener.Start(app.ApplicationServices);

            ConfigureCustom(app, env);

            // Keep this last as this is the fallback when nothing else works - spit out the index file - SPA service replacement
            // Microsoft SPA Services has an accidental coupling to MVC Controllers and its route builder, besides all it is trying to do is fallback
            // when nothing else works - regardless of route builders or anything else
            app.Run(async context =>
            {
                if( Path.HasExtension(context.Request.Path)) await Task.CompletedTask;
                context.Request.Path = new PathString("/");
                var path = $"{env.ContentRootPath}/wwwroot/index.html";
                await context.Response.SendFileAsync(new PhysicalFileInfo(new FileInfo(path)));
            });            
        }


        public virtual void ConfigureServicesCustom(IServiceCollection services) {}
        public virtual void ConfigureContainerCustom(ContainerBuilder containerBuilder) {}
        public virtual void ConfigureCustom(IApplicationBuilder application, IHostingEnvironment env) {}

    }
}