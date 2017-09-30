/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Infrastructure.Application;
using Read;
using Domain;
using Events;
using Infrastructure.Events;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public IEnumerable<NationalSociety> Get()
        {
            return _nationalSociety.GetAll(); 
        }

		[HttpPost]
		public void Post()
		{
			_eventEmitter.Emit(Feature, new NationalSocietyCreated
			{
                Name = Guid.NewGuid().ToString(),
				Id = Guid.NewGuid()
			});
		}
    }
}
