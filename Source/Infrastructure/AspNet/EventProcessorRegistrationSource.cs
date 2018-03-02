/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Builder;
using Autofac.Core;
using doLittle.Events.Processing;

namespace Infrastructure.AspNet
{
    internal class EventProcessorRegistrationSource : IRegistrationSource
    {
        public bool IsAdapterForIndividualComponents => false;

        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service,
            Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            var serviceWithType = service as IServiceWithType;

            if (serviceWithType == null || !typeof(ICanProcessEvents).IsAssignableFrom(serviceWithType.ServiceType))
                return Enumerable.Empty<IComponentRegistration>();

            var builder = RegistrationBuilder.ForType(serviceWithType.ServiceType);
            return new[] {builder.CreateRegistration()};
        }
    }
}