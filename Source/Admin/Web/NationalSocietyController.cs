/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Events;
using Infrastructure.Application;
using Infrastructure.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Read;
using System;
using System.Collections.Generic;

namespace Web
{
    [Route("api/nationalsociety")]
    public class NationalSocietyController : Controller
    {
        public static readonly Feature Feature = "NationalSociety";

        readonly INationalSocieties _nationalSociety;
        readonly IEventEmitter _eventEmitter;
        readonly ILogger<ProjectController> _logger;

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