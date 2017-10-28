using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Read.HealthRiskFeatures;
using Read.ProjectFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    [Route("api/projects/{projectId}")]
    public class ProjectsHealthRisksController : BaseController
    {
        readonly ILogger<ProjectsHealthRisksController> _logger;
        readonly IProjects _projects;
        readonly IHealthRisks _healthRisks;


        public ProjectsHealthRisksController(
            IProjects projects,
            IHealthRisks healthRisks,
            ILogger<ProjectsHealthRisksController> logger)
        {
            _projects = projects;
            _healthRisks = healthRisks;
            _logger = logger;
        }

        [HttpGet("healthRisks")]
        public IEnumerable<HealthRisk> GetHealthRisks(Guid projectId)
        {
            var project = _projects.GetById(projectId);
            var healthRisks = _healthRisks.GetAll();

            return healthRisks.Where(v => project.HealthRiskIds.Contains(v.Id));
        }
    }
}
