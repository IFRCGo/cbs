using Microsoft.AspNetCore.Mvc;
using Read.AnonymousCaseReportFeatures;
using Read.HealthRiskFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web
{
    [Route("api/anonymouscasereports")]
    public class AnonymousCaseReportsController
    {
        private readonly IAnonymousCaseReports _anonymousCaseReports;
        private readonly IHealthRisks _healthRisks;

        public AnonymousCaseReportsController(IAnonymousCaseReports anonymousCaseReports, IHealthRisks healthRisks)
        {
            _anonymousCaseReports = anonymousCaseReports;
            _healthRisks = healthRisks;
        }

        [HttpGet]
        public async Task<IEnumerable<AnonymousCaseReportExpanded>> Get()
        {
            var anonymousCaseReports = await _anonymousCaseReports.GetAllAsync();
            return anonymousCaseReports.Select(v => new AnonymousCaseReportExpanded(v, _healthRisks));
        }
    }
}
