using Microsoft.AspNetCore.Mvc;
using Read.DataCollectors;
using Read.CaseReports;
using Read.HealthRisks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Read.InvalidCaseReports;

namespace Web
{
    [Route("api/invalidcasereports")]
    public class InvalidCaseReportsController
    {
        private readonly IInvalidCaseReports _invalidCaseReports;
        private readonly IDataCollectors _dataCollectors;

        public InvalidCaseReportsController(IInvalidCaseReports invalidCaseReports, IDataCollectors dataCollectors)
        {
            _invalidCaseReports = invalidCaseReports;
            _dataCollectors = dataCollectors;
        }

        [HttpGet]
        public async Task<IEnumerable<InvalidCaseReportExpanded>> Get()
        {
            var invalidCaseReports = await _invalidCaseReports.GetAllAsync();

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
                var dataCollector = _dataCollectors.GetById(caseReport.DataCollectorId);
                return new InvalidCaseReportExpanded(caseReport, dataCollector);
            });
        }
    }
}
