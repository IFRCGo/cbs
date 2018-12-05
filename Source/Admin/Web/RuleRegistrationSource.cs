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
using Rules;

namespace Web
{
    public class RuleRegistrationSource : IRegistrationSource
    {
        static Dolittle.DependencyInversion.IContainer _container;
        static Dictionary<Type, Type> _rulesByDelegate;

        //static property for holding the container is only temp, we need a better pattern for handling this
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

            if (_container == null)
                return Enumerable.Empty<IComponentRegistration>();

            var serviceWithType = service as IServiceWithType;
            if (serviceWithType == null || _rulesByDelegate == null || !_rulesByDelegate.ContainsKey(serviceWithType.ServiceType))
                return Enumerable.Empty<IComponentRegistration>();

            var registration = new ComponentRegistration(
                Guid.NewGuid(),
                BuildDelegate(serviceWithType.ServiceType),
                new CurrentScopeLifetime(),
                InstanceSharing.None,
                InstanceOwnership.OwnedByLifetimeScope,
                new[] { service },
                new Dictionary<string, object>()
            );

            return new[] { registration };
        }

        DelegateActivator BuildDelegate(Type serviceType)
        {
            return new DelegateActivator(serviceType, (c, p) =>
            {
                var ruleImplementation = _rulesByDelegate[serviceType];
                var instance = c.Resolve(ruleImplementation);
                var ruleProperty = ruleImplementation.GetProperty("Rule", BindingFlags.Instance | BindingFlags.Public);
                var rule = ruleProperty.GetGetMethod().Invoke(instance, null);
                return rule;
            });
        }
    }
}