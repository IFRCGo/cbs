/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Core;
using Autofac.Core.Activators.Delegate;
using Autofac.Core.Lifetime;
using Autofac.Core.Registration;

namespace Infrastructure.AspNet.StringLocalization
{
    internal class LocalizedStringsRegistrationsSource : IRegistrationSource
    {
        private readonly ILocalizedStringsParser _parser;
        private readonly IUnparsedStringsProvider _provider;

        public LocalizedStringsRegistrationsSource(ILocalizedStringsParser parser, IUnparsedStringsProvider provider)
        {
            _parser = parser;
            _provider = provider;
        }

        public bool IsAdapterForIndividualComponents => false;

        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service,
            Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            if (!(service is IServiceWithType serviceWithType) ||
                serviceWithType.ServiceType != typeof(LocalizedStringsProvider))
                return Enumerable.Empty<IComponentRegistration>();

            var unparsed = _provider.GetUnparsedLocalizedStrings();
            var stringProviders = unparsed.Select(_parser.ParseStrings);

            var registrations = stringProviders.Select(provider =>
                new ComponentRegistration(
                    Guid.NewGuid(),
                    new DelegateActivator(
                        serviceWithType.ServiceType, (c, p) => provider),
                    new CurrentScopeLifetime(),
                    InstanceSharing.Shared,
                    InstanceOwnership.OwnedByLifetimeScope,
                    new[] {service},
                    new Dictionary<string, object>()));

            return registrations;
        }
    }
}