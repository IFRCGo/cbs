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

            // Comment from woksin - 15/02-2018
            // By fetching all risks and dataCollectors to memory we should get reduced latency,
            // which was the case when I tested this method using the old method versus fetching the data prior to querying it.
            // In my opinion, the best way to do this is to have a cache-system for these databases (preferably in the classes that deals directly
            // with IMongoDatabase and IMongoCollection 
            var healthRisks = await _healthRisks.GetAllAsync();
            var dataCollectors = await _dataCollectors.GetAllAsync();
            // Comment from review; einari - 23rd of October 2017
            // Todo: This is a N+1 query - potentially incredibly slow
            // an optimization would be to get all healthrisks and then
            // do inmemory lookups. Also moved this away from being done inside the CaseReportExtended
            // object - as it should not be having a relationship to repositories
            return caseReports.Select(caseReport =>
            {
                var dataCollector = dataCollectors.FirstOrDefault(collector => collector.Id == caseReport.DataCollectorId);
                var healthRisk = healthRisks.FirstOrDefault(risk => risk.Id == caseReport.HealthRiskId);
               
                //var healthRisk2 = _healthRisks.GetById(caseReport.HealthRiskId);
                //var dataCollector2 = _dataCollectors.GetById(caseReport.DataCollectorId);
                return new CaseReportExpanded(caseReport, dataCollector, healthRisk);
            });
           
        }
    }
}
