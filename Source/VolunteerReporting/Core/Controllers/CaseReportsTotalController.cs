//using System.Linq;
//using Microsoft.AspNetCore.Mvc;
//using Read.CaseReportsForListing;

//namespace Web.Controllers
//{
//    [Route("api/casereportstotal")]
//    public class CaseReportsTotalController : Controller
//    {
//        private readonly ICaseReportsForListing _caseReports;

//        public CaseReportsTotalController(ICaseReportsForListing caseReports)
//        {
//            _caseReports = caseReports;
//        }

//        [HttpGet]
//        public IActionResult Get()
//        {
//            //TODO: Remove this controller/hack and make the total count a port of the AllCaseReportsForListing-Query
//            return Ok(_caseReports.GetAll().Count());
//        }
//    }
//}
