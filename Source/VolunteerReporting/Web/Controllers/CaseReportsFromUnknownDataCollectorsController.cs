using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Read.CaseReports;
using Read.DataCollectors;
using Read.HealthRisks;
using Web.Models;

namespace Web
{
    [Route("api/casereportsfromunknowndatacollectors")]
    public class CaseReportsFromUnknownDataCollectorsController
    {
        private readonly ICaseReportsFromUnknownDataCollectors _caseReportsFromUnknownDataCollectors;
        private readonly IHealthRisks _healthRisks;

        public CaseReportsFromUnknownDataCollectorsController(
            ICaseReportsFromUnknownDataCollectors caseReportsFromUnknownDataCollectors,
            IHealthRisks healthRisks)
            
        {
            _caseReportsFromUnknownDataCollectors = caseReportsFromUnknownDataCollectors;
            _healthRisks = healthRisks;
        }

        [HttpGet]
        public async Task<IEnumerable<CaseReportFromUnknownDataCollectorExpanded>> Get()
        {
            var anonymousCaseReports = await _caseReportsFromUnknownDataCollectors.GetAllAsync();
            // Comment from review; einari - 23rd of October 2017
            // Todo: This is a N+1 query - potentially incredibly slow
            // an optimization would be to get all healthrisks and then
            // do inmemory lookups. Also moved this away from being done inside the CaseReportExtended
            // object - as it should not be having a relationship to repositories
            return anonymousCaseReports.Select(caseReport => {
                var healthRisk = _healthRisks.GetById(caseReport.HealthRiskId);
                return new CaseReportFromUnknownDataCollectorExpanded(caseReport, healthRisk);
            });
        }
    }
}
