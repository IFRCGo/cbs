using System.Reflection;
using doLittle.Assemblies;
using doLittle.Assemblies.Configuration;
using doLittle.Logging;
using doLittle.Types;
using Infrastructure.AspNet;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class doLittleServices
    {

        public static IServiceCollection Add_doLittle(this IServiceCollection services)
        {
            var logAppenders = LoggingConfigurator.DiscoverAndConfigure(Internals.LoggerFactory);
            doLittle.Logging.ILogger logger = new Logger(logAppenders);

            var assembliesConfigurationBuilder = new AssembliesConfigurationBuilder();
            assembliesConfigurationBuilder.IncludeAll();

            var contractToImplementorsMap = new ContractToImplementorsMap();
            var executingAssembly = typeof(doLittleServices).GetTypeInfo().Assembly;
            contractToImplementorsMap.Feed(executingAssembly.GetTypes());

            var assemblySpecifiers = new AssemblySpecifiers(assembliesConfigurationBuilder.RuleBuilder, logger);
            assemblySpecifiers.SpecifyUsingSpecifiersFrom(executingAssembly);

            var assembliesConfiguration = new AssembliesConfiguration(assembliesConfigurationBuilder.RuleBuilder);
            var assemblyFilters = new AssemblyFilters(assembliesConfiguration);
            var assemblyProvider = new AssemblyProvider(
                new ICanProvideAssemblies[] {new DefaultAssemblyProvider(logger)},
                assemblyFilters,
                new AssemblyUtility(),
                assemblySpecifiers);
            Internals.Assemblies = assemblyProvider.GetAll();

            services.AddSingleton<IAssemblyFilters>(assemblyFilters);
            services.AddSingleton<AssembliesConfiguration>(assembliesConfiguration);
            services.AddSingleton<IAssemblyProvider>(assemblyProvider);
            services.AddSingleton<IAssemblies>(new Assemblies(assemblyProvider));
            services.AddSingleton(typeof(doLittle.DependencyInversion.IContainer), typeof(Container));
            return services;
        }
    }
}