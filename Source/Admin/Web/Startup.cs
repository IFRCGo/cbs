/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.IO;
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



        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddCommon();
        //}

        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    app.Use(async (context, next) =>
        //    {
        //        await next();

        //        if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
        //        {
        //            context.Request.Path = "/index.html";
        //            await next();
        //        }
        //    });

        //    app.UseCommon(env);
        //}
    }
}