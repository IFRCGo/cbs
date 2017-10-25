using AspNet.MongoDB;
using Autofac;
using doLittle.Collections;
using doLittle.Types;
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
        }
    }
}