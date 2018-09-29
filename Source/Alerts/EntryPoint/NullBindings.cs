using Dolittle.DependencyInversion;
using Dolittle.Events.Coordination;
using Dolittle.ReadModels;
using Dolittle.ReadModels.MongoDB;
using Dolittle.Runtime.Events.Coordination;
using Dolittle.Runtime.Events.Processing;
using Dolittle.Runtime.Events.Processing.MongoDB;
using Dolittle.Runtime.Events.Store;
using MongoDB.Driver;


namespace Web
{
    public class NullBindings : ICanProvideBindings
    {
        public void Provide(IBindingProviderBuilder builder)
        {

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Alerts_EventStore");
            builder.Bind<IMongoDatabase>().To(database);
            
            builder.Bind<IEventStore>().To<Dolittle.Runtime.Events.Store.MongoDB.EventStore>();

            builder.Bind<Dolittle.ReadModels.MongoDB.Configuration>().To(new Dolittle.ReadModels.MongoDB.Configuration
            {
                Url = "mongodb://localhost:27017",
                UseSSL = false,
                DefaultDatabase = "Alerts_ReadModels"
            });
            builder.Bind(typeof(IReadModelRepositoryFor<>)).To(typeof(ReadModelRepositoryFor<>));

            builder.Bind<IEventProcessorOffsetRepository>().To<EventProcessorOffsetRepository>();
        }
    }
}