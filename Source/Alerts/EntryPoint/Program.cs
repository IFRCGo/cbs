/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Autofac.Extensions.DependencyInjection;
using System.IO;

namespace Web
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                
                .ConfigureServices(services => services.AddAutofac())
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>();
    }
}
