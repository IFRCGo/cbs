using System.Collections.Generic;

namespace Nyss.Web.Features.Report
{
    public interface IReportService
    {
        IEnumerable<ReportViewModel> All();
    }
}
