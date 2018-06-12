using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;
using Concepts;

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

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return (await _collection.FindAsync(_ => true)).ToList();
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

        public Task SaveProjectAsync(ProjectId id, string name)
        {
            return UpdateAsync(new Project
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

        public Task<UpdateResult> UpdateProjectAsync(ProjectId id, string name)
        {
            return UpdateAsync(p => p.Id == id,
                Builders<Project>.Update.Set(p => p.Name, name));
        }
    }
}
