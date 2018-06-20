using Microsoft.AspNetCore.Mvc;
using Read.DataCollectors;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Read.InvalidCaseReports;
using Infrastructure.AspNet;
using Concepts.DataCollector;
namespace Web.Controllers
{
    [Route("api/invalidcasereports")]
    public class InvalidCaseReportsController : Controller
    {
        private readonly IInvalidCaseReports _invalidCaseReports;
        private readonly IDataCollectors _dataCollectors;

        public InvalidCaseReportsController(IInvalidCaseReports invalidCaseReports, IDataCollectors dataCollectors)
        {
            _invalidCaseReports = invalidCaseReports;
            _dataCollectors = dataCollectors;
        }

        [HttpGet]
        public IEnumerable<InvalidCaseReportExpanded> Get()
        {
            var invalidCaseReports = _invalidCaseReports.GetAll();
            
            // Comment from woksin - 15/02-2018
            // By fetching all dataCollectors to memory we should get reduced latency,
            // which was the case when I tested this method using the old method versus fetching the data prior to querying it.
            // In my opinion, the best way to do this is to have a cache-system for these databases (preferably in the classes that deals directly
            // with IMongoDatabase and IMongoCollection 
            var dataCollectors = _dataCollectors.GetAll();
            // Following over from CaseReportController...
            // (half -as bad, but still half-assed)
            //
            // Comment from review; einari - 23rd of October 2017
            // Todo: This is a N+1 query - potentially incredibly slow
            // an optimization would be to get all data collectors and all healthrisks and then
            // do inmemory lookups. Also moved this away from being done inside the CaseReportExtended
            // object - as it should not be having a relationship to repositories
            return invalidCaseReports.Select(caseReport => 
            {
                var dataCollector = dataCollectors.FirstOrDefault(collector => collector.Id == caseReport.DataCollectorId);
                //var dataCollector2 = _dataCollectors.GetById(caseReport.DataCollectorId);
                return new InvalidCaseReportExpanded(caseReport, dataCollector);
            });
        }
    }
}
