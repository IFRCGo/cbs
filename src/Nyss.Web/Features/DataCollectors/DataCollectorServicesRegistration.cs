using Microsoft.Extensions.DependencyInjection;

namespace Nyss.Web.Features.DataCollectors
{
    public static class DataCollectorServicesRegistration
    {
        public static void RegisterDatacollectorsFeature(this IServiceCollection services)
        {
            services.AddScoped<IDataCollectorsService, DataCollectorsService>();
        }
    }
}
