using System.Collections.Generic;
using System.Reflection;
using Autofac;
using doLittle.Assemblies;
using doLittle.Assemblies.Configuration;
using doLittle.Collections;
using doLittle.Logging;
using doLittle.Types;
using FluentValidation.AspNetCore;
using Infrastructure.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace WebApi
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
            var assemblyFilters = new AssemblyFilters(assembliesConfiguration);
            var assemblyProvider = new AssemblyProvider(
                new ICanProvideAssemblies[] {new DefaultAssemblyProvider(logger)},
                assemblyFilters,
                new AssemblyUtility(),
                assemblySpecifiers);
            _assemblies = assemblyProvider.GetAll();

            services.AddSingleton<IAssemblyFilters>(assemblyFilters);
            services.AddSingleton<AssembliesConfiguration>(assembliesConfiguration);
            services.AddSingleton<IAssemblyProvider>(assemblyProvider);
            services.AddSingleton<IAssemblies>(new Assemblies(assemblyProvider));
            services.AddSingleton(typeof(doLittle.DependencyInversion.IContainer), typeof(WebApi.Container));

            //builder.RegisterInstance(assemblyProvider).As<IAssemblyProvider>();
            //builder.RegisterInstance(new Assemblies(assemblyProvider)).As<IAssemblies>();

            services
                .AddCors()
                .AddMvc()
                .AddFluentValidation(fv => {
                    _assemblies.ForEach(assembly => fv.RegisterValidatorsFromAssembly(assembly));
                });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<NullEventStore>().As<IEventStore>();
            builder.RegisterType<NullEventPublisher>().As<IEventPublisher>();
            builder.RegisterGeneric(typeof(InstancesOf<>)).As(typeof(IInstancesOf<>));
            builder.RegisterGeneric(typeof(ImplementationsOf<>)).As(typeof(IImplementationsOf<>));

            _assemblies.ForEach(assembly => builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces());

            builder.RegisterSource(new WebApi.EventProcessorRegistrationSource());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Relaxed CORS policy for example only
            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowCredentials());
            app.UseMvc();
        }
    }
}