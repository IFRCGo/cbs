/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Read.HealthRiskFeatures;
using System;

namespace Web
{
    [Route("api/healthRisk")]
    public class HealthRiskController : Controller
    {
        private readonly IHealthRisks _healthRisks;
        private readonly ILogger<HealthRiskController> _logger;

        public HealthRiskController(
            IHealthRisks healthRisks,
            ILogger<HealthRiskController> logger)
        {
            _healthRisks = healthRisks;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<HealthRisk>> Get()
        {
            return await _healthRisks.GetAllAsync();
        }

        [HttpGet("{id}")]
        public HealthRisk Get(Guid id)
        {
            return _healthRisks.GetById(id);
        }

        [HttpPost]
        [Route("addhealthrisk")]
        public IActionResult AddHealthRisk([FromBody]HealthRisk healthRisk)
        {
            _healthRisks.SaveAsync(healthRisk);

            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] HealthRisk healthRisk)
        {
            _healthRisks.ReplaceAsync(healthRisk);

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _healthRisks.RemoveAsync(id);

            return Ok();
        }
    }
}