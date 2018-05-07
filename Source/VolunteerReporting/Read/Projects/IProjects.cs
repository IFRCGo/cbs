using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.Projects
{
    public interface IProjects : IGenericReadModelRepositoryFor<Project, Guid>
    {
        IEnumerable<Project> GetAll();
        Task<IEnumerable<Project>> GetAllAsync();
        Project GetById(Guid project);
    }
}
