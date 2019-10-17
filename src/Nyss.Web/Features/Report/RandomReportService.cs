
using System;

namespace Nyss.Web.Features.Report
{
    public class ReportService : IReportService
    {
        public ReportViewModel GenerateRandomReport()
        {
            var dt = DateTime.Now;
        }
    }
}