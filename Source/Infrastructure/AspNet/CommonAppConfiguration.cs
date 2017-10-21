using System.Collections.Generic;
using System.Reflection;
using Infrastructure.AspNet;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Builder
{
    public static class CommonAppConfiguration
    {


        public static IApplicationBuilder UseCommon(this IApplicationBuilder app, IHostingEnvironment env)
        {
            Internals.ServiceProvider = app.ApplicationServices;

            // Relaxed CORS policy for example only
            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowCredentials());
            app.UseMvc();
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();


            return app;
        }

    }
}