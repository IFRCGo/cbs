/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Infrastructure.Application;
using Infrastructure.Events;
using Read;
using Domain;
using Events;

namespace Web
{
    [Route("api/project")]
    public class ProjectController : Controller
    {
        public static readonly Feature Feature = "Project";

        readonly IProjects _projects;
        readonly IEventEmitter _eventEmitter;
        readonly ILogger<ProjectController> _logger;

        public ProjectController(
            IProjects projects,
            IPricing pricing,
            IEventEmitter eventEmitter,
            ILogger<ProjectController> logger)
        {
            _eventEmitter = eventEmitter;
            _logger = logger;
            _projects = projects;
        }


        [HttpGet]
        public Cart Get()
        {
            return new Cart();
        }


        [HttpPost]
        public void Post([FromBody]CreateProject command)
        {
           

            _eventEmitter.Emit(Feature, new CreatedProject
            {
              Name = command.Name,
              Id = Guid.NewGuid()
            });
        }

        [HttpDelete("items/{id}")]
        public void Remove(Guid id)
        {

        }
    }
}