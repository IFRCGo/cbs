using Microsoft.AspNetCore.Mvc;
using Read.DataCollectors;
using Read.CaseReports;
using Read.HealthRisks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Infrastructure.AspNet;
using Read.CaseReportsForListing;

namespace Web
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

        [HttpGet("export")]
        public async Task<IActionResult> Export()
        {
            string[] fields = {};
            return Ok(await _caseReports.ExportCsv(fields));
        }
    }
}
