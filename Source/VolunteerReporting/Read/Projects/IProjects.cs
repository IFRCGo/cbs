using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.Projects
{
    public interface IProjects
    {
        Task<IEnumerable<Project>> GetAllAsync();
        void Save(Project project);
        Project GetById(Guid project);
    }
}
