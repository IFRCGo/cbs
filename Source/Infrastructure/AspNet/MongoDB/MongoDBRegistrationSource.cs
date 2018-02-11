/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using Autofac.Core.Activators.Delegate;
using Autofac.Core.Lifetime;
using Autofac.Core.Registration;
using Infrastructure.AspNet.ConnectionStrings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AspNet.MongoDB
{
    public class MongoDBRegistrationSource : IRegistrationSource
    {
        public bool IsAdapterForIndividualComponents => false;

        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service,
            Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            var serviceWithType = service as IServiceWithType;

            if (serviceWithType == null || serviceWithType.ServiceType != typeof(IMongoDatabase))
                return Enumerable.Empty<IComponentRegistration>();

            var registration = new ComponentRegistration(
                Guid.NewGuid(),
                new DelegateActivator(serviceWithType.ServiceType, (c, p) =>
                {
                    var connectionStrings = c.Resolve<IOptions<ConnectionStringsOptions>>().Value;
                    var connectionString =
                        connectionStrings.ConnectionStrings.SingleOrDefault(t =>
                            t.Type == ConnectionStringType.MongoDB);
                    if (connectionString == null)
                        throw new MissingConnectionStringForDatabaseType(ConnectionStringType.MongoDB);

                    var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString.Value));
                    var mongoClient = new MongoClient(settings);
                    var database = mongoClient.GetDatabase(connectionString.Database);

                    return database;
                }),
                new CurrentScopeLifetime(),
                InstanceSharing.Shared,
                InstanceOwnership.OwnedByLifetimeScope,
                new[] {service},
                new Dictionary<string, object>()
            );

            return new[] {registration};
        }
    }
}