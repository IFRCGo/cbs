using Microsoft.AspNetCore.Mvc;
using Read.Reporting.CaseReportsForListing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/casereportstotal")]
    public class CaseReportsTotalController : Controller
    {
        private readonly AllCaseReportsForListing _caseReports;

        public CaseReportsTotalController(AllCaseReportsForListing caseReports)
        {
            _caseReports = caseReports;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //TODO: Remove this controller/hack and make the total count a port of the AllCaseReportsForListing-Query
            return Ok(_caseReports.Query.Count());
        }
    }
}
