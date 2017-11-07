using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Read.InvalidCaseReports;
using Read.DataCollectors;
using Read.HealthRisks;
using Web.Models;

namespace Web
{
    [Route("api/invalidcasereportsfromunknowndatacollectors")]
    public class InvalidCaseReportsFromUnknownDataCollectorsController
    {
        private readonly IInvalidCaseReportsFromUnknownDataCollectors _invalidCaseReportsFromUnknownDataCollectors;

        public InvalidCaseReportsFromUnknownDataCollectorsController(
            IInvalidCaseReportsFromUnknownDataCollectors invalidCaseReportsFromUnknownDataCollectors)
            
        {
            _invalidCaseReportsFromUnknownDataCollectors = invalidCaseReportsFromUnknownDataCollectors;
        }

        [HttpGet]
        public Task<IEnumerable<InvalidCaseReportFromUnknownDataCollector>> Get()
        {
            return _invalidCaseReportsFromUnknownDataCollectors.GetAllAsync();
        }
    }
}
