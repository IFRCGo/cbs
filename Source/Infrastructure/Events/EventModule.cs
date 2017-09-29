/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Autofac;

namespace Infrastructure.Events
{
    /// <summary>
    /// Represents the Autofac module for dealing with events infrastructure
    /// </summary>
    public class EventModule : Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NullEventStore>().As<IEventStore>();
            builder.RegisterType<NullEventPublisher>().As<IEventPublisher>();
        }
    }
}