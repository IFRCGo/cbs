/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Reflection;
using Dolittle.Assemblies;
using Dolittle.Assemblies.Configuration;
using Dolittle.Logging;
using Dolittle.Types;
using Infrastructure.AspNet;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DolittleServices
    {
        public static IServiceCollection Add_Dolittle(this IServiceCollection services)
        {
            var logAppenders = LoggingConfigurator.DiscoverAndConfigure(Internals.LoggerFactory);
            Dolittle.Logging.ILogger logger = new Logger(logAppenders);

            var assembliesConfigurationBuilder = new AssembliesConfigurationBuilder();
            assembliesConfigurationBuilder.IncludeAll();

            var contractToImplementorsMap = new ContractToImplementorsMap();
            var executingAssembly = typeof(DolittleModule).GetTypeInfo().Assembly;
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
            Internals.AllAssemblies = assemblyProvider.GetAll();
            Internals.AssemblyFilters = assemblyFilters;
            Internals.AssembliesConfiguration = assembliesConfiguration;
            Internals.AssemblyProvider = assemblyProvider;
            Internals.Assemblies = new Assemblies(assemblyProvider);

            return services;
        }
    }
}