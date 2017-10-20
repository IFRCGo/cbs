using Microsoft.AspNetCore.Mvc;
using Read.AnonymousCaseReportFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    [Route("api/anonymouscasereports")]
    public class AnonymousCaseReportsController
    {
        private readonly IAnonymousCaseReports _anonymousCaseReports;
        public AnonymousCaseReportsController(IAnonymousCaseReports anonymousCaseReports)
        {
            _anonymousCaseReports = anonymousCaseReports;
        }

        [HttpGet]
        public async Task<IEnumerable<AnonymousCaseReport>> Get()
        {
            return await _anonymousCaseReports.GetAllAsync();
        }
    }
}
