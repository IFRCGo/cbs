using AspNet.MongoDB;
using Autofac;
using doLittle.Collections;
using doLittle.Types;
using Infrastructure.Application;
using Infrastructure.Events;
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
            builder.RegisterInstance<ApplicationInformation>(new ApplicationInformation(Internals.BoundedContext));

            builder.RegisterGeneric(typeof(InstancesOf<>)).As(typeof(IInstancesOf<>));
            builder.RegisterGeneric(typeof(ImplementationsOf<>)).As(typeof(IImplementationsOf<>));

            Internals.Assemblies.ForEach(assembly => 
            {
                builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
                builder.RegisterAssemblyModules(assembly);
            });

            builder.RegisterSource(new EventProcessorRegistrationSource());
            builder.RegisterSource(new MongoDBRegistrationSource());
        }
    }
}