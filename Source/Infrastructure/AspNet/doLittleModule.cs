/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Globalization;
using System.Security.Claims;
using Autofac;
using doLittle.Assemblies;
using doLittle.Assemblies.Configuration;
using doLittle.Collections;
using doLittle.Domain;
using doLittle.Events.Processing;
using doLittle.Logging;
using doLittle.Runtime.Applications;
using doLittle.Runtime.Commands;
using doLittle.Runtime.Events.Coordination;
using doLittle.Runtime.Events.Processing;
using doLittle.Runtime.Events.Publishing;
using doLittle.Runtime.Events.Publishing.InProcess;
using doLittle.Runtime.Events.Storage;
using doLittle.Runtime.Execution;
using doLittle.Runtime.Tenancy;
using doLittle.Types;

namespace Infrastructure.AspNet
{
    public class doLittleModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var logAppenders = LoggingConfigurator.DiscoverAndConfigure(Internals.LoggerFactory);
            doLittle.Logging.ILogger logger = new Logger(logAppenders);
            builder.RegisterType<Logger>().As<doLittle.Logging.ILogger>().SingleInstance();

            builder.RegisterType<ControllerActionCommandContextManager>().As<ICommandContextManager>().SingleInstance();

            builder.RegisterGeneric(typeof(InstancesOf<>)).As(typeof(IInstancesOf<>));
            builder.RegisterGeneric(typeof(ImplementationsOf<>)).As(typeof(IImplementationsOf<>));
            builder.RegisterGeneric(typeof(AggregateRootRepositoryFor<>)).As(typeof(IAggregateRootRepositoryFor<>));

            builder.RegisterInstance(Internals.AssemblyFilters).As<IAssemblyFilters>();
            builder.RegisterInstance(Internals.AssembliesConfiguration).As<AssembliesConfiguration>();
            builder.RegisterInstance(Internals.AssemblyProvider).As<IAssemblyProvider>();
            builder.RegisterInstance(Internals.Assemblies).As<IAssemblies>();

            Internals.Assemblies.GetAll().ForEach(assembly => builder.RegisterAssemblyTypes(assembly).AsSelf().AsImplementedInterfaces());

            builder.RegisterType<Container>().As<doLittle.DependencyInversion.IContainer>().SingleInstance();
            builder.RegisterType<UncommittedEventStreamCoordinator>().As<IUncommittedEventStreamCoordinator>()
                .SingleInstance();
            builder.RegisterType<Infrastructure.AspNet.EventProcessors>().As<IEventProcessors>().SingleInstance();
            builder.RegisterType<NullEventProcessorLog>().As<IEventProcessorLog>().SingleInstance();
            builder.RegisterType<NullEventProcessorStates>().As<IEventProcessorStates>().SingleInstance();
            builder.RegisterType<NullEventStore>().As<IEventStore>().SingleInstance();
            builder.RegisterType<NullEventSourceVersions>().As<IEventSourceVersions>().SingleInstance();
            builder.RegisterType<NullEventSequenceNumbers>().As<IEventSequenceNumbers>().SingleInstance();

            builder.RegisterType<CommittedEventStreamSender>().As<ICanSendCommittedEventStream>().SingleInstance();
            builder.RegisterType<CommittedEventStreamReceiver>().As<ICanReceiveCommittedEventStream>().SingleInstance();
            builder.RegisterType<CommittedEventStreamBridge>().As<ICommittedEventStreamBridge>().SingleInstance();
            builder.RegisterType<CommittedEventStreamCoordinator>().As<ICommittedEventStreamCoordinator>().SingleInstance();
            builder.RegisterType<ProcessMethodEventProcessors>().AsSelf().SingleInstance();

            var applicationStructureBuilder =
                new ApplicationStructureConfigurationBuilder()
                    .Include(ApplicationAreas.Domain,
                        "Infrastructure.AspNet.-{BoundedContext}.-{Module}.-{Feature}.^{SubFeature}*")
                    .Include(ApplicationAreas.Domain, "Domain.-{BoundedContext}.-{Module}.-{Feature}.^{SubFeature}*")
                    .Include(ApplicationAreas.Events, "Events.-{BoundedContext}.-{Module}.-{Feature}.^{SubFeature}*")
                    .Include(ApplicationAreas.Read, "Read.-{BoundedContext}.-{Module}.-{Feature}.^{SubFeature}*");

            var applicationStructure = applicationStructureBuilder.Build();
            var applicationName = (ApplicationName) "CBS";
            var application = new Application(applicationName, applicationStructure);
            builder.Register(_ => application).As<IApplication>().SingleInstance();
            builder.Register(_ => Internals.BoundedContext).AsSelf();

            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(identity.NameClaimType, "[Anonymous]"));
            var principal = new ClaimsPrincipal(identity);

            var tenant = new Tenant("IFRC");

            builder.RegisterInstance(tenant).As<ITenant>();

            builder.Register(_ =>
                new doLittle.Runtime.Execution.ExecutionContext(
                    principal,
                    CultureInfo.InvariantCulture,
                    (context, details) => { },
                    application,
                    tenant)
            ).As<IExecutionContext>();

            builder.RegisterSource(new EventProcessorRegistrationSource());
        }
    }
}