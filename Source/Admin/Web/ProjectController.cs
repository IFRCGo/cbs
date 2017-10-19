/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Domain;
using Events;
using Infrastructure.Application;
using Infrastructure.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Read;
using Read.ProjectFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web
{
    [Route("api/project")]
    public class ProjectController : Controller
    {
        public static readonly Feature Feature = "Project";

        readonly IEventEmitter _eventEmitter;

        readonly ILogger<ProjectController> _logger;

        readonly IProjects _projects;

        public ProjectController(
            IProjects projects,
            IEventEmitter eventEmitter,
            ILogger<ProjectController> logger)
        {
            _eventEmitter = eventEmitter;
            _logger = logger;
            _projects = projects;
        }

        [HttpGet]
        public async Task<IEnumerable<Project>> Get()
        {
            return await _projects.GetAllASync();
        }

        [HttpGet("{id}")]
        public Project Get(Guid id)
        {
            return _projects.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] CreateProject command)
        {
            _eventEmitter.Emit(Feature, new ProjectCreated
            {
                Name = command.Name,
                Id = command.Id,
                NationalSocietyId = command.NationalSocietyId,
                OwnerUserId = command.OwnerUserId
            });
        }

        [HttpDelete("items/{id}")]
        public void Remove(Guid id)
        {
        }
    }
}