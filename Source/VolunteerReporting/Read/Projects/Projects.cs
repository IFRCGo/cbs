using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.Projects
{
    public class Projects : GenericReadModelRepositoryFor<Project, Guid>,
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

        public Project GetById(Guid projectId)
        {
            return GetOne(p => p.Id == projectId);
        }

        public void SaveProject(Guid id, string name)
        {
            Save(new Project
            {
                Id = id,
                Name = name
            });
        }

        public Task SaveProjectAsync(Guid id, string name)
        {
            return SaveAsync(new Project
            {
                Id = id,
                Name = name
            });
        }

        public UpdateResult UpdateProject(Guid id, string name)
        {
            return UpdateOne(p => p.Id == id,
                Builders<Project>.Update.Set(p => p.Name, name));
        }

        public Task<UpdateResult> UpdateProjectAsync(Guid id, string name)
        {
            return UpdateOneAsync(p => p.Id == id,
                Builders<Project>.Update.Set(p => p.Name, name));
        }
    }
}
