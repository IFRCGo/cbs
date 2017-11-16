using Microsoft.AspNetCore.Mvc;
using Read.DataCollectors;
using Read.CaseReports;
using Read.HealthRisks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Infrastructure.AspNet;

namespace Web
{
    [Route("api/casereports")]
    public class CaseReportsController : BaseController
    {
        private readonly ICaseReports _caseReports;
        private readonly IHealthRisks _healthRisks;
        private readonly IDataCollectors _dataCollectors;

        public CaseReportsController(ICaseReports caseReports, IHealthRisks healthRisks, IDataCollectors dataCollectors)
        {
            _caseReports = caseReports;
            _healthRisks = healthRisks;
            _dataCollectors = dataCollectors;
        }

        [HttpGet]
        public async Task<IEnumerable<CaseReportExpanded>> Get()
        {
            var caseReports = await _caseReports.GetAllAsync();

            // Comment from review; einari - 23rd of October 2017
            // Todo: This is a N+1 query - potentially incredibly slow
            // an optimization would be to get all data collectors and all healthrisks and then
            // do inmemory lookups. Also moved this away from being done inside the CaseReportExtended
            // object - as it should not be having a relationship to repositories
            return caseReports.Select(caseReport => 
            {
                var dataCollector = _dataCollectors.GetById(caseReport.DataCollectorId);
                var healthRisk = _healthRisks.GetById(caseReport.HealthRiskId);
                
                return new CaseReportExpanded(caseReport, dataCollector, healthRisk);
            });
        }
    }
}
