using Microsoft.Extensions.DependencyInjection;
using Nyss.Web.Features.SmsGateway.Logic;

namespace Nyss.Web.Features.Report
{
    public static class ReportServicesRegistration
    {
        public static void RegisterReportFeature(this IServiceCollection services)
        {
            services.AddScoped<ISmsGatewayService, InFileSmsGatewayService>();
        }
    }
}
