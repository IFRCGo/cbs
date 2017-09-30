using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read
{
    public interface IProjects
    {
        Project GetById(Guid id);
        void Save(Project project);

        IEnumerable<Project> GetAll();
        Task<IEnumerable<Project>> GetAllASync();
    }
}
