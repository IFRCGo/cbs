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

        public HealthRiskController(
            IHealthRisks healthRisks)
        {
            _healthRisks = healthRisks;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _healthRisks.GetAllAsync());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_healthRisks.GetById(id));
        }
        
    }
}