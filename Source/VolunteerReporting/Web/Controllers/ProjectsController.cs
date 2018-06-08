using Microsoft.AspNetCore.Mvc;
using Read.Projects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : Controller
    {
        private IProjects _projects;

        public ProjectsController(IProjects projects)
        {
            _projects = projects;
        }

        [HttpGet]
        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await _projects.GetAllAsync();
        }
    }
}
