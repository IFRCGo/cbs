using Domain;
using Events;
using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Read.HealthRiskFeatures;
using Read.ProjectFeatures;
using System;
using System.Linq;

namespace Web
{
    [Route("api/projects/{projectId}")]
    public class ProjectsHealthRiskController : BaseController
    {
        readonly ILogger<ProjectsHealthRiskController> _logger;
        readonly IProjects _projects;
        readonly IHealthRisks _healthRisks;
        private readonly IProjectHealthRiskVersions _healthRiskVersions;

        public ProjectsHealthRiskController(
            IProjects projects,
            IHealthRisks healthRisks,
            IProjectHealthRiskVersions healthRiskVersions,
            ILogger<ProjectsHealthRiskController> logger)
        {
            _projects = projects;
            _healthRisks = healthRisks;
            _healthRiskVersions = healthRiskVersions;
            _logger = logger;
        }

        [HttpGet("healthRisks")]
        public IActionResult GetHealthRisks(Guid projectId)
        {
            var project = _projects.GetById(projectId);

            if (project != null)
            {
                var healthRisks = _healthRisks.GetAll();
                return Ok(
                    healthRisks.Where(healthRisk => project.HealthRisks.Any(projectHealthRisk => projectHealthRisk.HealthRiskId == healthRisk.Id))
                    .Select(v => new 
                    {
                        HealthRiskId = v.Id,
                        v.Name,
                        project.HealthRisks.First(x => x.HealthRiskId == v.Id).Threshold
                    })
                );
            }
            else
                return NotFound();
        }

        [HttpGet("healthRisks/{healthRiskId}")]
        public IActionResult GetHealthRisks(Guid projectId, Guid healthRiskId)
        {
            var project = _projects.GetById(projectId);

            if (project != null)
            {
                var projectHealthRisk = project.HealthRisks.FirstOrDefault(v => v.HealthRiskId == healthRiskId);
                if (projectHealthRisk != null)
                {
                    var healthRisk = _healthRisks.GetById(projectHealthRisk.HealthRiskId);
                    return Ok(
                        new
                        {
                            HealthRiskId = healthRiskId,
                            healthRisk.Name,
                            projectHealthRisk.Threshold
                        }
                    );
                }
            }

            return NotFound();
        }

        [HttpGet("healthRisks/{healthRiskId}/versions")]
        public IActionResult GetHealthRiskVersions(Guid projectId, Guid healthRiskId)
        {
            return Ok(_healthRiskVersions.GetByProjectIdAndHealthRiskId(projectId, healthRiskId));
        }

        [HttpPut("healthRisks/{healthRiskId}")]
        public IActionResult UpdateHealthRisk(Guid projectId, Guid healthRiskId, [FromBody] UpdateProjectHealthRiskThreshold updateProjectHealthRiskThreshold)
        {
            var id = Guid.NewGuid();
            Apply(id, new ProjectHealthRiskThresholdUpdate()
            {
                ProjectId = projectId,
                HealthRiskId = healthRiskId,
                Threshold = updateProjectHealthRiskThreshold.Threshold
            });
            return Ok();
        }

        [HttpDelete("healthRisks/{healthRiskId}")]
        public IActionResult RemoveHealthRisk(Guid projectId, Guid healthRiskId)
        {
            var id = Guid.NewGuid();
            Apply(id, new ProjectHealthRiskRemoved()
            {
                ProjectId = projectId,
                HealthRiskId = healthRiskId,
            });
            return Ok();
        }

        [HttpPost("healthRisks")]
        public IActionResult AddHealthRisk(Guid projectId, Guid healthRiskId, [FromBody] AddProjectHealthRisk addProjectHealthRisk)
        {
            var id = Guid.NewGuid();
            Apply(id, new ProjectHealthRiskAdded
            {
                ProjectId = projectId,
                HealthRiskId = healthRiskId,
                Threshold = addProjectHealthRisk.Threshold
            });
            return Ok();
        }
    }
}
