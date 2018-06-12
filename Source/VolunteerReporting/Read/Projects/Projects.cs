using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;

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
            return _collection.FindSync(_ => true).ToList();
        }

        public Project GetById(Guid projectId)
        {
            return GetOne(p => p.Id == projectId);
        }

        public void SaveProject(Guid id, string name)
        {
            Update(new Project
            {
                Id = id,
                Name = name
            });
        }

        public UpdateResult UpdateProject(Guid id, string name)
        {
            return Update(p => p.Id == id,
                Builders<Project>.Update.Set(p => p.Name, name));
        }
    }
}
