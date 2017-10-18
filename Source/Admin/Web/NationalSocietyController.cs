/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Events;
using Infrastructure.Application;
using Infrastructure.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Read;
using Read.NationalSocietyFeatures;

namespace Web
{

    /// <summary>
    /// API for NationalSociety
    /// </summary>
    [Route("api/nationalsociety")]
    public class NationalSocietyController : Controller
    {
        public static readonly Feature Feature = "NationalSociety";
        private readonly IEventEmitter _eventEmitter;
        private readonly ILogger<ProjectController> _logger;

        private readonly INationalSocieties _nationalSociety;

        public NationalSocietyController(
            INationalSocieties nationalSociety,
            IEventEmitter eventEmitter,
            ILogger<ProjectController> logger
        )
        {
            _logger = logger;
            _eventEmitter = eventEmitter;
            _nationalSociety = nationalSociety;
        }

        [HttpGet]
        public IEnumerable<NationalSociety> GetAllNationalSocieties()
        {
            return _nationalSociety.GetAll();
        }

        [HttpPost]
        public void AddNationalSociety()
        {
            _eventEmitter.Emit(Feature, new NationalSocietyCreated
            {
                Name = Guid.NewGuid().ToString(),
                Id = Guid.NewGuid()
            });
        }
    }
}