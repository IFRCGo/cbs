
using System.Security.Claims;
using Concepts;
using Dolittle.AspNetCore.Execution;
using Dolittle.DependencyInversion;
using Dolittle.Execution;
using Dolittle.ReadModels;
using Dolittle.Security;
using Dolittle.Tenancy;
using Microsoft.AspNetCore.Mvc;
using Read.Overview.LastWeeksPerHealthRisk;
using Read.Overview.LastWeekTotals;

namespace Core.Overview.LastWeekTotals
{
    [Route("api/CaseReport/TotalsPerHealthRisk")]
    public class LastWeekPerHealthRiskController : ControllerBase
    {
        readonly IExecutionContextConfigurator _executionContextConfigurator;
        readonly ITenantResolver _tenantResolver;
        readonly FactoryFor<IReadModelRepositoryFor<CaseReportsLastWeeksPerHealthRisk>> _lastWeekPerHealthRisk;

        public LastWeekPerHealthRiskController(
            IExecutionContextConfigurator executionContextConfigurator,
            ITenantResolver tenantResolver,
            FactoryFor<IReadModelRepositoryFor<CaseReportsLastWeeksPerHealthRisk>> lastWeekTotals)
        {
            _executionContextConfigurator = executionContextConfigurator;
            _tenantResolver = tenantResolver;
            _lastWeekPerHealthRisk = lastWeekTotals;
        }


        [HttpGet("")]
        public IActionResult LastWeek() 
        {
            _executionContextConfigurator.ConfigureFor(_tenantResolver.Resolve(HttpContext.Request), CorrelationId.New(), ClaimsPrincipal.Current.ToClaims());

            return Ok(_lastWeekPerHealthRisk().GetById(Day.Today));
        }
    }
}
