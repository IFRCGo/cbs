using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Read.CaseReports;
using Read.CaseReportsForListing;
using System.Threading.Tasks;
using Web.Utility;
using System.IO;
using System.Collections.Generic;
using Concepts;

using CaseReportForListing = Read.CaseReportsForListing.CaseReportForListing;
using Concepts.HealthRisk;
using Concepts.DataCollector;

namespace Web.Controllers
{
    [Route("api/casereportstotal")]
    public class CaseReportsTotalController : Controller
    {
        private readonly ICaseReportsForListing _caseReports;
        private readonly ICaseReports _caseReportsObsolete;

        public CaseReportsTotalController(ICaseReportsForListing caseReports, ICaseReports caseReportsObsolete)
        {
            _caseReports = caseReports;
            _caseReportsObsolete = caseReportsObsolete;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //TODO: Remove this controller/hack and make the total count a port of the AllCaseReportsForListing-Query
            return Ok(_caseReports.GetAll().Count());
        }
    }
}
