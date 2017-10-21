using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Security.Claims;
using Autofac;
using doLittle.Assemblies;
using doLittle.Assemblies.Configuration;
using doLittle.Events.Processing;
using doLittle.Logging;
using doLittle.Runtime.Applications;
using doLittle.Runtime.Events.Coordination;
using doLittle.Runtime.Events.Processing;
using doLittle.Runtime.Events.Storage;
using doLittle.Runtime.Execution;
using doLittle.Runtime.Tenancy;
using doLittle.Strings;
using doLittle.Types;

namespace Infrastructure.AspNet
{

    public class doLittleModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Container>().As<doLittle.DependencyInversion.IContainer>().SingleInstance();
            builder.RegisterType<UncommittedEventStreamCoordinator>().As<IUncommittedEventStreamCoordinator>().SingleInstance();
            builder.RegisterType<NullEventProcessors>().As<IEventProcessors>().SingleInstance();
            builder.RegisterType<NullEventProcessorLog>().As<IEventProcessorLog>().SingleInstance();
            builder.RegisterType<NullEventProcessorStates>().As<IEventProcessorStates>().SingleInstance();
            builder.RegisterType<NullEventStore>().As<IEventStore>().SingleInstance();
            builder.RegisterType<NullEventSourceVersions>().As<IEventSourceVersions>().SingleInstance();
            builder.RegisterType<NullEventSequenceNumbers>().As<IEventSequenceNumbers>().SingleInstance();
            builder.RegisterType<ProcessMethodEventProcessors>().AsSelf();

            var applicationStructureBuilder = 
                new ApplicationStructureConfigurationBuilder()
                    .Include(ApplicationAreas.Domain,"Infrastructure.AspNet.-{BoundedContext}.-{Module}.-{Feature}.^{SubFeature}*")
                    .Include(ApplicationAreas.Domain,"Domain.-{BoundedContext}.-{Module}.-{Feature}.^{SubFeature}*")
                    .Include(ApplicationAreas.Events,"Events.-{BoundedContext}.-{Module}.-{Feature}.^{SubFeature}*")
                    .Include(ApplicationAreas.Read,"Read.-{BoundedContext}.-{Module}.-{Feature}.^{SubFeature}*");

            var applicationStructure = applicationStructureBuilder.Build();
            var applicationName = (ApplicationName)"CBS";
            var application = new Application(applicationName,applicationStructure);
            builder.Register(_ => application).As<IApplication>().SingleInstance();

            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(identity.NameClaimType, "[Anonymous]"));
            var principal = new ClaimsPrincipal(identity);
            
            builder.Register(_ =>  
                
                new ExecutionContext(
                    principal,
                    CultureInfo.InvariantCulture,
                    (context, details) => {},
                    application,
                    new Tenant("IFRC"))
            ).As<IExecutionContext>();

            
        }
    }
}