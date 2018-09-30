/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dolittle.Collections;
using Dolittle.Events.Processing;
using Dolittle.Execution;
using Dolittle.Runtime.Tenancy;
using Events.HealthRisks;
using Infrastructure.Events;
using Infrastructure.Read;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Web
{
    /*
    public class HealthRiskEventProcessorsForDistributionToOtherTenants : ICanProcessEvents
    {
        readonly ITenants _tenants;
        private readonly IExecutionContextManager _executionContextManager;
        private readonly IEventReplayer _eventPlayer;

        public HealthRiskEventProcessorsForDistributionToOtherTenants(ITenants tenants, IExecutionContextManager executionContextManager, IEventReplayer eventPlayer)
        {
            _tenants = tenants;
            _executionContextManager = executionContextManager;
            _eventPlayer = eventPlayer;
        }

        public void Process(HealthRiskCreated @event)
        {
            var currentTenant = _executionContextManager.Current.Tenant;

            var filtered = _tenants.All.Where(_ => _ != currentTenant);
            filtered.ForEach(tenant =>
            {
                Task.Run(() =>
                {
                    _executionContextManager.CurrentFor(tenant);
                    _eventPlayer.Replay(new[] { @event })
                });
            });
        }
    }
    */

    public class Startup : Infrastructure.AspNet.Startup
    {
        public Startup(
            ILoggerFactory loggerFactory,
            IHostingEnvironment env,
            IConfiguration configuration) : base(loggerFactory, env, configuration)
        { }
    }
}