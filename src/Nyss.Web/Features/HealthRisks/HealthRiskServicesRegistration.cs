using Microsoft.Extensions.DependencyInjection;

namespace Nyss.Web.Features.HealthRisks
{
    public static class HealthRiskServicesRegistration
    {
        public static void RegisterHealthRiskFeature(this IServiceCollection services)
        {
            services.AddScoped<IHealthRisksService, HealthRisksService>();
        }
    }
}
