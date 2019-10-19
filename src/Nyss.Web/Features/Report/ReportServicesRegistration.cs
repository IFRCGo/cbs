using Microsoft.Extensions.DependencyInjection;
using Nyss.Web.Features.Report.Data;

namespace Nyss.Web.Features.Report
{
    public static class ReportServicesRegistration
    {
        public static void RegisterReportFeature(this IServiceCollection services)
        {
            services.AddScoped<IReportService, RandomReportService>();
            services.AddScoped<IReportRepository, InMemoryReportRepository>();
        }
    }
}
