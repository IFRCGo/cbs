using System;
using System.Linq;
using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Read.CaseReports;
using Read.CaseReportsForListing;
using Read.DataCollectors;
using Read.HealthRisks;
using System.Threading.Tasks;
using Web.Utility;

namespace Web.Controllers
{
    [Route("api/casereports")]
    public class CaseReportsController : BaseController
    {
        private readonly ICaseReportsForListing _caseReports;
        private readonly ICaseReports _caseReportsObsolete;
        private readonly IHealthRisks _healthRisks;
        private readonly IDataCollectors _dataCollectors;

        public CaseReportsController(ICaseReportsForListing caseReports, ICaseReports caseReportsObsolete, IHealthRisks healthRisks, IDataCollectors dataCollectors)
        {
            _caseReports = caseReports;
            _caseReportsObsolete = caseReportsObsolete;
            _healthRisks = healthRisks;
            _dataCollectors = dataCollectors;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _caseReports.GetAllAsync());
        }

        [Route("pdf")]
        [HttpGet]
        public async Task<IActionResult> PdfReport()
        {
            var now = DateTimeOffset.UtcNow;

            var caseReports = await _caseReports.GetAllAsync();

            var pdfBytes = PdfUtility.CreateCaseReportPdf(caseReports.ToList(), new[] { "all" });

            return File(pdfBytes, "application/pdf",
                "casereports-" + DateTimeOffset.UtcNow.ToString("yyyy-MMMM-dd") + ".pdf");
            
        }

        [HttpGet("obsolete")]
        [Obsolete]
        public async Task<IActionResult> GetObsolete()
        {
            return Ok(await _caseReportsObsolete.GetAllAsync());
        }

        [Obsolete]
        [HttpGet("getlimitlast")] // Used as api/casereports/getlimitlast?limit=..
        public async Task<IActionResult> GetLimitLast(int limit)
        {
            return Ok(await _caseReports.GetLimitAsync(limit, true));
        }
        [Obsolete]
        [HttpGet("getlimitfirst")] // Used as api/casereports/getlimitfirst?limit=..
        public async Task<IActionResult> GetLimitFirst(int limit)
        {
            return Ok(await _caseReports.GetLimitAsync(limit, false));
        }

    }
}
