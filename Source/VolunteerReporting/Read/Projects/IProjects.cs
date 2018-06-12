using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Infrastructure.Read.MongoDb;

namespace Read.Projects
{
    public interface IProjects : IExtendedReadModelRepositoryFor<Project>
    {
        IEnumerable<Project> GetAll();
        Project GetById(Guid project);

        void SaveProject(Guid id, string name);

        UpdateResult UpdateProject(Guid id, string name);
    }
}
