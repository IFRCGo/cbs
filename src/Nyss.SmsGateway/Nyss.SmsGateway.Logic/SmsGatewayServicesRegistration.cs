using Microsoft.Extensions.DependencyInjection;
using Nyss.SmsGateway.Data;

namespace Nyss.SmsGateway.Logic
{
    public static class SmsGatewayServicesRegistration
    {
        public static void RegisterSmsGateway(this IServiceCollection services)
        {
            services.AddScoped<ISmsGatewayService, InFileSmsGatewayService>();
            services.AddScoped<ISmsGatewayRepository, FakeSmsGatewayRepository>();
        }
    }
}
