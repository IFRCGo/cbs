using Microsoft.Extensions.DependencyInjection;

namespace Nyss.Web.Features.SmsGateway.Logic
{
    public static class SmsGatewayServicesRegistration
    {
        public static void RegisterSmsGateway(this IServiceCollection services)
        {
            services.AddScoped<ISmsGatewayService, InFileSmsGatewayService>();
        }
    }
}
