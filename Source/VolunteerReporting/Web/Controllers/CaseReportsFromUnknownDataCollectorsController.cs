using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Read.CaseReports;
using Read.DataCollectors;
using Read.HealthRisks;
using Web.Models;
using Infrastructure.AspNet;

namespace Web.Controllers
{
    [Route("api/casereportsfromunknowndatacollectors")]
    public class CaseReportsFromUnknownDataCollectorsController : Controller
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
        public IEnumerable<CaseReportFromUnknownDataCollectorExpanded> Get()
        {
            var anonymousCaseReports = _caseReportsFromUnknownDataCollectors.GetAll();

            // Comment from woksin - 15/02-2018
            // By fetching all risks to memory we should get reduced latency,
            // which was the case when I tested this method using the old method versus fetching the data prior to querying it.
            // In my opinion, the best way to do this is to have a cache-system for these databases (preferably in the classes that deals directly
            // with IMongoDatabase and IMongoCollection 
            var healthRisks = _healthRisks.GetAll();

            // Comment from review; einari - 23rd of October 2017
            // Todo: This is a N+1 query - potentially incredibly slow
            // an optimization would be to get all healthrisks and then
            // do inmemory lookups. Also moved this away from being done inside the CaseReportExtended
            // object - as it should not be having a relationship to repositories
            
            return anonymousCaseReports.Select(caseReport => {
                var healthRisk = healthRisks.FirstOrDefault(risk => risk.Id == caseReport.HealthRiskId);
                
               
                //var healthRisk2 = _healthRisks.GetById(caseReport.HealthRiskId);
                return new CaseReportFromUnknownDataCollectorExpanded(caseReport, healthRisk);
            });
        }
    }
}
