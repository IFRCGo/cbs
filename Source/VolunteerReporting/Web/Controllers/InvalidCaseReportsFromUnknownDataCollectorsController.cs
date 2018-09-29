using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Read.InvalidCaseReports;

namespace Web.Controllers
{
    [Route("api/invalidcasereportsfromunknowndatacollectors")]
    public class InvalidCaseReportsFromUnknownDataCollectorsController : Controller
    {
        private readonly IInvalidCaseReportsFromUnknownDataCollectors _invalidCaseReportsFromUnknownDataCollectors;

        public InvalidCaseReportsFromUnknownDataCollectorsController(
            IInvalidCaseReportsFromUnknownDataCollectors invalidCaseReportsFromUnknownDataCollectors)
            
        {
            _invalidCaseReportsFromUnknownDataCollectors = invalidCaseReportsFromUnknownDataCollectors;
        }

        [HttpGet]
        public IEnumerable<InvalidCaseReportFromUnknownDataCollector> Get()
        {
            return _invalidCaseReportsFromUnknownDataCollectors.GetAll();
        }
    }
}
