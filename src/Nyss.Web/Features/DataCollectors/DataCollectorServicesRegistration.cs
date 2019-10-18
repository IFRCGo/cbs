using Microsoft.Extensions.DependencyInjection;
using Nyss.Web.Features.DataCollectors.Export;
using Nyss.Web.Features.DataCollectors.Export.Formats;

namespace Nyss.Web.Features.DataCollectors
{
    public static class DataCollectorServicesRegistration
    {
        public static void RegisterDataCollectorsFeature(this IServiceCollection services)
        {
            services.AddScoped<IDataCollectorsService, DataCollectorsService>();
            services.AddScoped<ICanExportDataCollectors, ExcelExporter>();
        }
    }
}
