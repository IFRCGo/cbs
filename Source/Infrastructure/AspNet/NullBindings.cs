using System.Globalization;
using System.Security.Claims;
using Dolittle.Security;
using Dolittle.Runtime.Commands.Handling;

using Dolittle.Commands.Handling;
using Dolittle.DependencyInversion;
using Dolittle.Runtime.Events.Store;
using Dolittle.Runtime.Events.Coordination;
using Dolittle.ReadModels;
using Dolittle.Events.Coordination;
using Dolittle.ReadModels.MongoDB;
using Dolittle.Runtime.Events.Processing;
using Dolittle.Runtime.Events.Processing.MongoDB;

namespace Infrastructure.AspNet
{
    /// <summary>
    /// 
    /// </summary>
    public class NullBindings : ICanProvideBindings
    {
        /// <inheritdoc/>
        public void Provide(IBindingProviderBuilder builder)
        {
            builder.Bind<Dolittle.ReadModels.MongoDB.Configuration>().To(new Dolittle.ReadModels.MongoDB.Configuration
            {
                Url = "mongodb://localhost:27017",
                UseSSL = false,
                DefaultDatabase = "admin"
            });
            builder.Bind<IEventStore>().To<Dolittle.Runtime.Events.Store.MongoDB.EventStore>();
            builder.Bind(typeof(IReadModelRepositoryFor<>)).To(typeof(ReadModelRepositoryFor<>));
            builder.Bind<IEventProcessorOffsetRepository>().To<EventProcessorOffsetRepository>();
        }
    }
}