/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Infrastructure.Application;
using Infrastructure.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Read;
using System.Threading.Tasks;
using Read.HealthRiskFeatures;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web
{
    [Route("api/healthRisk")]
    public class HealthRiskController : Controller
    {
        public static readonly Feature Feature = "HealthRisk";

        private readonly IHealthRisks _healthRisks;
        private readonly IEventEmitter _eventEmitter;
        private readonly ILogger<HealthRiskController> _logger;

        public HealthRiskController(
            IHealthRisks healthRisks,
            IEventEmitter eventEmitter,
            ILogger<HealthRiskController> logger)
        {
            _healthRisks = healthRisks;
            _eventEmitter = eventEmitter;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<HealthRisk>> Get()
        {
            return await _healthRisks.GetAllAsync();
        }
    }
}