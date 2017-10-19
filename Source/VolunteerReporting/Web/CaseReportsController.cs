using Microsoft.AspNetCore.Mvc;
using Read.CaseReportFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    [Route("api/casereports")]
    public class CaseReportsController
    {
        private readonly ICaseReports _caseReports;
        public CaseReportsController(ICaseReports caseReports)
        {
            _caseReports = caseReports;
        }

        [HttpGet]
        public async Task<IEnumerable<CaseReport>> Get()
        {
            return await _caseReports.GetAllAsync();
        }
    }
}
