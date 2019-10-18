using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_reportService.All());
        }
    }
}
