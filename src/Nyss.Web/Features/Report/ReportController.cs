using Nyss.Web.Utils;

namespace Nyss.Web.Features.Report
{
    public class ReportController : BaseController
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        //TODO: Action that return list of reports
    }
}
