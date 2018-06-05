using Infrastructure.Read.MongoDb;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.AspNet
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddReadModule(this IServiceCollection services)
        {
            services.AddTransient<IReadModule>();
            return services;
        }
    }
}