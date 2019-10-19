using Microsoft.Extensions.DependencyInjection;

namespace Nyss.Web.Features.SmsGateway.Logic
{
    public static class ReportServicesRegistration
    {
        public static void RegisterSmsGatewayFeature(this IServiceCollection services)
        {
            services.AddScoped<ISmsGatewayService, InFileSmsGatewayService>();
            services.AddScoped<ISmsParser, SmsParser>();
        }
    }
}