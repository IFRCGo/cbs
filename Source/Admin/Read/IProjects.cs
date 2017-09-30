using System;
using System.Collections.Generic;
using System.Text;

namespace Read
{
    public interface IProjects
    {
        Project GetById(Guid id);
        void Save(Project project);

        IEnumerable<Project> GetAll();
    }
}
