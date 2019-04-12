using Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();
            services.AddSwaggerDocument();

            return services.RegisterDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSecurity(env, "/analytics");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(_ => {
                    _.AllowAnyHeader();
                    _.AllowAnyMethod();
                    _.AllowAnyOrigin();
                    _.AllowCredentials();
                });
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UsePathBase("/analytics");

            app.UseSwagger();
            app.UseSwaggerUi3();

            app.UseMvc();
            app.ServeSinglePageApplication();
        }
    }
}
