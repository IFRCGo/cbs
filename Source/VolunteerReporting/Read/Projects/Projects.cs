using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;
using Concepts;
using Concepts.Project;

namespace Read.Projects
{
    public class Projects : ExtendedReadModelRepositoryFor<Project>,
        IProjects
    {
        public Projects(IMongoDatabase database)
            : base(database, database.GetCollection<Project>("Project"))
        {
        }

        public IEnumerable<Project> GetAll()
        {
            return GetMany(_ => true);
        }

        public Project GetById(ProjectId projectId)
        {
            return GetOne(p => p.Id == projectId);
        }

        public void SaveProject(ProjectId id, string name)
        {
            Update(new Project
            {
                Id = id,
                Name = name
            });
        }

        public UpdateResult UpdateProject(ProjectId id, string name)
        {
            return Update(p => p.Id == id,
                Builders<Project>.Update.Set(p => p.Name, name));
        }
    }
}
