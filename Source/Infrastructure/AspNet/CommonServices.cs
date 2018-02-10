/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using doLittle.Collections;
using FluentValidation.AspNetCore;
using Infrastructure.AspNet;
using Infrastructure.AspNet.ConnectionStrings;
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
                    config.Filters.Add(new CommandFilter());
                })
                .AddFluentValidation(fv =>
                {
                    Internals.AllAssemblies.ForEach(assembly => fv.RegisterValidatorsFromAssembly(assembly));
                });
            ;
            services.Configure<ConnectionStringsOptions>(Internals.Configuration);

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "My API", Version = "v1"}); });

            return services;
        }
    }
}