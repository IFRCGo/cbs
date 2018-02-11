/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using AspNet.MongoDB;
using Autofac;
using doLittle.Collections;
using Infrastructure.AspNet.StringLocalization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Infrastructure.AspNet
{
    public class Startup
    {
        public Startup(ILoggerFactory loggerFactory, IHostingEnvironment env, IConfiguration configuration)
        {
            Internals.Configuration = configuration;
            Internals.LoggerFactory = loggerFactory;
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            Internals.AllAssemblies.ForEach(assembly =>
            {
                builder.RegisterAssemblyModules(assembly);
                builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
            });

            builder.RegisterSource(new MongoDBRegistrationSource());
            builder.RegisterSource(new LocalizedStringsRegistrationsSource(new LocalizedStringsParser(),
                new UnparsedStringsProvider()));

            // TODO: Fix auto discovery for generics
            builder.RegisterGeneric(typeof(LocalizedStringsFactory<>))
                .As(typeof(ILocalizedStringsFactory<>));
        }
    }
}