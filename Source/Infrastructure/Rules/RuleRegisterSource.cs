/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2018 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Autofac.Core.Activators.Delegate;
using Autofac.Core.Lifetime;
using Autofac.Core.Registration;
using Dolittle.Types;

namespace Infrastructure.Rules
{
    public class RuleRegistrationSource : IRegistrationSource
    {
        static Dolittle.DependencyInversion.IContainer _container;
        static Dictionary<Type, Type> _rulesByDelegate;

        public static Dolittle.DependencyInversion.IContainer Container
        {
            get { return _container; }
            set
            {
                if (_container != null) throw new Exception("You should not set the container twice");

                _container = value;
                var typeFinder = _container.Get<ITypeFinder>();
                _rulesByDelegate = typeFinder.FindMultiple(typeof(IRuleImplementationFor<>))
                                                .ToDictionary(_ =>
                                                {
                                                    var @interface = _.GetInterface(typeof(IRuleImplementationFor<>).Name);
                                                    return @interface.GetGenericArguments()[0];
                                                }, _ => _);
            }
        }
        public bool IsAdapterForIndividualComponents => false;

        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            if (Container == null) return Enumerable.Empty<IComponentRegistration>();

            var serviceWithType = service as IServiceWithType;
            var interfaces = serviceWithType.ServiceType.GetInterfaces();
            if (serviceWithType == null || !_rulesByDelegate.ContainsKey(serviceWithType.ServiceType)) return Enumerable.Empty<IComponentRegistration>();

            var registration = new ComponentRegistration(
                Guid.NewGuid(),
                new DelegateActivator(serviceWithType.ServiceType, (c, p) => {
                    var ruleImplementation = _rulesByDelegate[serviceWithType.ServiceType];
                    var instance = c.Resolve(ruleImplementation);
                    var ruleProperty = ruleImplementation.GetProperty("Rule", BindingFlags.Instance | BindingFlags.Public);
                    var rule = ruleProperty.GetGetMethod().Invoke(instance, null);
                    return rule;
                }),
                new CurrentScopeLifetime(),
                InstanceSharing.None,
                InstanceOwnership.OwnedByLifetimeScope,
                new[] { service },
                new Dictionary<string, object>()
            );

            return new[] { registration };
        }
    }
}

