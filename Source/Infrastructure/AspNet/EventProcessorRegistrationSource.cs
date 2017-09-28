using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Builder;
using Autofac.Core;
using Infrastructure.Events;

namespace Infrastructure.AspNet
{
    public class EventProcessorRegistrationSource : IRegistrationSource
    {
        public bool IsAdapterForIndividualComponents => false;

        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            var serviceWithType = service as IServiceWithType;
            
            if( serviceWithType == null || !typeof(IEventProcessor).IsAssignableFrom(serviceWithType.ServiceType))
                return Enumerable.Empty<IComponentRegistration>();


            var builder = RegistrationBuilder.ForType(serviceWithType.ServiceType);
            return new[] { builder.CreateRegistration() };
        }
    }
}