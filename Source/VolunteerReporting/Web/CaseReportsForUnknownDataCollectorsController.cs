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
    [Route("api/casereportsforunknowndatacollectors")]
    public class CaseReportsForUnknownDataCollectorsController
    {
        private readonly ICaseReportsFromUnknownDataCollectors _caseReportsForUnknownDataCollectors;
        private readonly IHealthRisks _healthRisks;

        public CaseReportsForUnknownDataCollectorsController(
            ICaseReportsFromUnknownDataCollectors caseReportsForUnknownDataCollectors,
            IHealthRisks healthRisks)
            
        {
            _caseReportsForUnknownDataCollectors = caseReportsForUnknownDataCollectors;
            _healthRisks = healthRisks;
        }

        [HttpGet]
        public async Task<IEnumerable<CaseReportForUnknownDataCollectorExpanded>> Get()
        {
            var anonymousCaseReports = await _caseReportsForUnknownDataCollectors.GetAllAsync();
            // Comment from review; einari - 23rd of October 2017
            // Todo: This is a N+1 query - potentially incredibly slow
            // an optimization would be to get all healthrisks and then
            // do inmemory lookups. Also moved this away from being done inside the CaseReportExtended
            // object - as it should not be having a relationship to repositories
            return anonymousCaseReports.Select(caseReport => {
                var healthRisk = _healthRisks.GetById(caseReport.HealthRiskId);
                return new CaseReportForUnknownDataCollectorExpanded(caseReport, healthRisk);
            });
        }
    }
}
