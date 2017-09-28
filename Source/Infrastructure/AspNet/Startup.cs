using System.Collections.Generic;
using System.Reflection;
using Autofac;
using doLittle.Collections;
using doLittle.Types;
using Infrastructure.Application;
using Infrastructure.Events;
using Microsoft.Extensions.Logging;

namespace Infrastructure.AspNet
{
    public class Startup
    {

        public Startup(ILoggerFactory loggerFactory)
        {
            Internals.LoggerFactory = loggerFactory;
        }
        
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterInstance<ApplicationInformation>(new ApplicationInformation(Internals.BoundedContext));

            builder.RegisterType<NullEventStore>().As<IEventStore>();
            builder.RegisterType<NullEventPublisher>().As<IEventPublisher>();
            builder.RegisterGeneric(typeof(InstancesOf<>)).As(typeof(IInstancesOf<>));
            builder.RegisterGeneric(typeof(ImplementationsOf<>)).As(typeof(IImplementationsOf<>));

            Internals.Assemblies.ForEach(assembly => builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces());

            /*
            var settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://127.0.0.1:27017/shopping"));
            var mongoClient = new MongoClient(settings);
            var database = mongoClient.GetDatabase("test");
            var collection = database.GetCollection<Cart>("Cart");
            
            collection.InsertOne(new Cart {
                Id = System.Guid.NewGuid()
            });
            */

            builder.RegisterSource(new EventProcessorRegistrationSource());
        }
    }
}