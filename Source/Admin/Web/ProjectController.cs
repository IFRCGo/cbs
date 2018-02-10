/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Domain;
using Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Read.ProjectFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.AspNet;

namespace Web
{
    [Route("api/project")]
    public class ProjectController : BaseController
    {
        readonly ILogger<ProjectController> _logger;

        readonly IProjects _projects;

        public ProjectController(
            IProjects projects,
            ILogger<ProjectController> logger)
        {
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
            Apply(command.Id, new ProjectCreated
            {
                Name = command.Name,
                Id = command.Id,
                NationalSocietyId = command.NationalSocietyId,
                DataOwnerId = command.DataOwnerId,
                SurveillanceContext = command.SurveillanceContext
            });
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] UpdateProject command)
        {
            Apply(id, new ProjectUpdated
            {
                Id = command.Id = id,
                Name = command.Name,
                NationalSocietyId = command.NationalSocietyId,
                DataOwnerId = command.DataOwnerId,
                SurveillanceContext = command.SurveillanceContext
            });
        }

        [HttpPost("{id}/dataverifiers")]
        public void AddDataVerifier(Guid id, [FromBody]AddDataVerifier command)
        {
            Apply(id, new DataVerifierAdded
            {
                ProjectId = command.ProjectId = id,
                UserId = command.UserId
            });
        }

        [HttpDelete("{id}/dataverifiers/{userId}")]
        public void RemoveDataVerifier(Guid id, Guid userId)
        {
            Apply(id, new DataVerifierRemoved
            {
                ProjectId = id,
                UserId = userId
            });
        }

        [HttpDelete("{id}")]
        public void Remove(Guid id)
        {
           
        }
    }
}