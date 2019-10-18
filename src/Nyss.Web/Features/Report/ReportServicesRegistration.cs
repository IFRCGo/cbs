using Microsoft.Extensions.DependencyInjection;
using Nyss.Web.Features.Report.Export;
using Nyss.Web.Features.Report.Export.Formats;
using Nyss.Web.Features.SmsGateway.Logic;

namespace Nyss.Web.Features.Report
{
    public static class ReportServicesRegistration
    {
        public static void RegisterReportFeature(this IServiceCollection services)
        {
            services.AddScoped<ISmsGatewayService, InFileSmsGatewayService>();
            services.AddScoped<ICanExportCaseReports, ExcelExporter>();
        }
    }
}
