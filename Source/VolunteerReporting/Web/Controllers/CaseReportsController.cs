using System;
using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Read.CaseReports;
using Read.CaseReportsForListing;
using Read.DataCollectors;
using Read.HealthRisks;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/casereports")]
    public class CaseReportsController : Controller
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

        [HttpGet("obsolete")]
        [Obsolete]
        public async Task<IActionResult> GetObsolete()
        {
            return Ok(await _caseReportsObsolete.GetAllAsync());
        }

        [HttpGet("getlimitlast")] // Used as api/casereports/getlimitlast?limit=..
        public async Task<IActionResult> GetLimitLast(int limit)
        {
            return Ok(await _caseReports.GetLimitAsync(limit, true));
        }

        [HttpGet("getlimitfirst")] // Used as api/casereports/getlimitfirst?limit=..
        public async Task<IActionResult> GetLimitFirst(int limit)
        {
            return Ok(await _caseReports.GetLimitAsync(limit, false));
        }
    }
}
