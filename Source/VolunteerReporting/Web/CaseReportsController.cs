using Microsoft.AspNetCore.Mvc;
using Read;
using Read.CaseReportFeatures;
using Read.HealthRiskFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web
{
    [Route("api/casereports")]
    public class CaseReportsController
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
            return caseReports.Select(v => new CaseReportExpanded(v, _dataCollectors, _healthRisks));
        }
    }
}
