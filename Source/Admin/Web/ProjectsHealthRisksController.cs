/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Microsoft.AspNetCore.Mvc;

namespace Web
{
    [Route("api/projects/{projectId}")]
    public class ProjectsHealthRiskController : Controller
    {
        //readonly ILogger<ProjectsHealthRiskController> _logger;
        //readonly IProjects _projects;
        //private readonly IProjectHealthRiskVersions _healthRiskVersions;

        //public ProjectsHealthRiskController(
        //    IProjects projects,
        //    IProjectHealthRiskVersions healthRiskVersions,
        //    ILogger<ProjectsHealthRiskController> logger)
        //{
        //    _projects = projects;
        //    _healthRiskVersions = healthRiskVersions;
        //    _logger = logger;
        //}


        //TODO: Integrate to DoLittle2.0
        //[HttpPut("healthRisks/{healthRiskId}")]
        //public IActionResult UpdateHealthRisk(Guid projectId, Guid healthRiskId,
        //    [FromBody] UpdateProjectHealthRiskThreshold updateProjectHealthRiskThreshold)
        //{
        //    var id = Guid.NewGuid();
        //    Apply(id, new ProjectHealthRiskThresholdUpdate()
        //    {
        //        ProjectId = projectId,
        //        HealthRiskId = healthRiskId,
        //        Threshold = updateProjectHealthRiskThreshold.Threshold
        //    });
        //    return Ok();
        //}

        //[HttpDelete("healthRisks/{healthRiskId}")]
        //public IActionResult RemoveHealthRisk(Guid projectId, Guid healthRiskId)
        //{
        //    var id = Guid.NewGuid();
        //    Apply(id, new ProjectHealthRiskRemoved()
        //    {
        //        ProjectId = projectId,
        //        HealthRiskId = healthRiskId,
        //    });
        //    return Ok();
        //}

        //[HttpPost("healthRisks")]
        //public IActionResult AddHealthRisk(Guid projectId, Guid healthRiskId,
        //    [FromBody] AddProjectHealthRisk addProjectHealthRisk)
        //{
        //    var id = Guid.NewGuid();
        //    Apply(id, new ProjectHealthRiskAdded
        //    {
        //        ProjectId = projectId,
        //        HealthRiskId = healthRiskId,
        //        Threshold = addProjectHealthRisk.Threshold
        //    });
        //    return Ok();
        //}
    }
}