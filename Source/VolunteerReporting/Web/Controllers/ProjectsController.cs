using Infrastructure.AspNet;
using Microsoft.AspNetCore.Mvc;
using Read.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : BaseController
    {
        private IProjects _projects;

        public ProjectsController(IProjects projects)
        {
            _projects = projects;
        }

        [HttpGet]
        public Task<IEnumerable<Project>> GetAllProjects()
        {
            return _projects.GetAllAsync();
        }
    }
}
