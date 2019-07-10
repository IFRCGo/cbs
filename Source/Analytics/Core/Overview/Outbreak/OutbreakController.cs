using System.Security.Claims;
using Concepts;
using Concepts.HealthRisks;
using Dolittle.AspNetCore.Execution;
using Dolittle.DependencyInversion;
using Dolittle.Execution;
using Dolittle.ReadModels;
using Dolittle.Security;
using Dolittle.Tenancy;
using Microsoft.AspNetCore.Mvc;
using Read.Overview.Map;
using Read.Overview.LastWeekTotals;
using System;
using Newtonsoft.Json;

namespace Core.Overview.OutbreakController
{
    [Route("api/CaseReport/Outbreak")]
    public class OutbreakController : ControllerBase
    {
        readonly IExecutionContextConfigurator _executionContextConfigurator;
        readonly ITenantResolver _tenantResolver;
        readonly FactoryFor<IReadModelRepositoryFor<CaseReportsBeforeDay>> _Outbreaks;

        public OutbreakController(
            IExecutionContextConfigurator executionContextConfigurator,
            ITenantResolver tenantResolver,
            FactoryFor<IReadModelRepositoryFor<CaseReportsBeforeDay>> Outbreaks)
        {
            _executionContextConfigurator = executionContextConfigurator;
            _tenantResolver = tenantResolver;
            _Outbreaks = Outbreaks;
        }


        [HttpGet("Outbreaks")]
        public IActionResult Outbreaks() 
        {
            _executionContextConfigurator.ConfigureFor(_tenantResolver.Resolve(HttpContext.Request), CorrelationId.New(), ClaimsPrincipal.Current.ToClaims());
            HealthRiskId id =  Guid.Parse("9cd3c7b5-6973-45c3-a8d3-58d9eb38824c");
            return Ok(_Outbreaks().GetById(17925).CasesPerHealthRisk[id].CaseReportsLast7Days); 
        }
    }
}