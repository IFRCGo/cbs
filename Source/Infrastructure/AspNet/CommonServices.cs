using doLittle.Collections;
using FluentValidation.AspNetCore;
using Infrastructure.AspNet;
using Swashbuckle.AspNetCore.Swagger;

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

                
            services.AddSwaggerGen(c => 
                {
                    c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                });

            return services;
        }
    }
}