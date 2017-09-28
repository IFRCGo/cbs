using doLittle.Collections;
using FluentValidation.AspNetCore;
using Infrastructure.AspNet;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CommonServices
    {
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            services
                .Add_doLittle()
                .AddCors()
                .AddMvc(config =>
                {
                    config.Filters.Add(new ValidationFilter());

                })
                .AddFluentValidation(fv =>
                {
                    Internals.Assemblies.ForEach(assembly => fv.RegisterValidatorsFromAssembly(assembly));
                });

            return services;
        }
    }
}