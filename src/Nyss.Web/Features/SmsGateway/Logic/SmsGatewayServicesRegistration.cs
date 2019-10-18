using Microsoft.Extensions.DependencyInjection;
using Nyss.Web.Features.Report;
using Nyss.Web.Features.Report.Data;

namespace Nyss.Web.Features.SmsGateway.Logic
{
    public static class ReportServicesRegistration
    {
        public static void RegisterSmsGatewayFeature(this IServiceCollection services)
        {
            services.AddScoped<IReportService, RandomReportService>();
            services.AddScoped<IReportRepository, InMemoryReportRepository>();
        }
    }
}
