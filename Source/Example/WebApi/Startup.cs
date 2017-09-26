using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using doLittle.Assemblies;
using doLittle.Assemblies.Configuration;
using doLittle.Collections;
using doLittle.IO;
using doLittle.Logging;
using doLittle.Types;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Web
{
    public class Startup
    {
        ILoggerFactory _loggerFactory;
        IEnumerable<Assembly> _assemblies;

        public Startup(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var logAppenders = LoggingConfigurator.DiscoverAndConfigure(_loggerFactory);
            doLittle.Logging.ILogger logger = new Logger(logAppenders);

            var assembliesConfigurationBuilder = new AssembliesConfigurationBuilder();
            assembliesConfigurationBuilder.IncludeAll();

            var contractToImplementorsMap = new ContractToImplementorsMap();
            var executingAssembly = typeof(Startup).GetTypeInfo().Assembly;
            contractToImplementorsMap.Feed(executingAssembly.GetTypes());

            var assemblySpecifiers = new AssemblySpecifiers(assembliesConfigurationBuilder.RuleBuilder, logger);
            assemblySpecifiers.SpecifyUsingSpecifiersFrom(executingAssembly);

            var assembliesConfiguration = new AssembliesConfiguration(assembliesConfigurationBuilder.RuleBuilder);
            var assemblyProvider = new AssemblyProvider(
                new ICanProvideAssemblies[] {new DefaultAssemblyProvider(logger)},
                new AssemblyFilters(assembliesConfiguration),
                new AssemblyUtility(),
                assemblySpecifiers);
            _assemblies = assemblyProvider.GetAll();

            services.AddSingleton<IAssemblyProvider>(assemblyProvider);
            services.AddSingleton<IAssemblies>(new Assemblies(assemblyProvider));

            //builder.RegisterInstance(assemblyProvider).As<IAssemblyProvider>();
            //builder.RegisterInstance(new Assemblies(assemblyProvider)).As<IAssemblies>();

            services
                .AddMvc()
                .AddFluentValidation(_ => {
                    _assemblies.ForEach(assembly => _.RegisterValidatorsFromAssembly(assembly));
                });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            _assemblies.ForEach(assembly => builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
