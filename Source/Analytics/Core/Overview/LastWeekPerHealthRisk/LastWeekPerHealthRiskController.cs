/*---------------------------------------------------------------------------------------------
*  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/

using System.Security.Claims;
using Concepts;
using Dolittle.AspNetCore.Execution;
using Dolittle.DependencyInversion;
using Dolittle.Execution;
using Dolittle.ReadModels;
using Dolittle.Security;
using Dolittle.Tenancy;
using Microsoft.AspNetCore.Mvc;
using Read.Overview.Last4WeeksPerHealthRisk;
using Read.Overview.LastWeekTotals;

namespace Core.Overview.LastWeekTotals
{
    [Route("api/CaseReport/TotalsPerHealthRisk")]
    public class LastWeekPerHealthRiskController : ControllerBase
    {
        readonly IExecutionContextConfigurator _executionContextConfigurator;
        readonly ITenantResolver _tenantResolver;
        readonly FactoryFor<IReadModelRepositoryFor<CaseReportsLast4WeeksPerHealthRisk>> _lastWeekPerHealthRisk;

        public LastWeekPerHealthRiskController(
            IExecutionContextConfigurator executionContextConfigurator,
            ITenantResolver tenantResolver,
            FactoryFor<IReadModelRepositoryFor<CaseReportsLast4WeeksPerHealthRisk>> lastWeekTotals)
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
