using System;
using Microsoft.AspNetCore.Mvc;
using Read.CaseReports;
using Read.Models.CaseReports;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseReportController : ControllerBase
    {
        private readonly CaseReportRepository _caseReportRepository;
        public CaseReportController(CaseReportRepository caseReportRepository)
        {
            _caseReportRepository = caseReportRepository;
        }

        [HttpGet("{from}/{to}", Name = "GetCaseReportTotals")]
        public ActionResult<CaseReportTotals> GetCaseReportTotals(DateTimeOffset from, DateTimeOffset to)
        {
            return _caseReportRepository.GetCaseReportTotals(from, to);
        }
    }
}