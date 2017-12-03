using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.Projects
{
    public class Projects : IProjects
    {
        readonly IMongoDatabase _database;
        readonly IMongoCollection<Project> _collection;

        public Projects(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<Project>("Project");
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            var filter = Builders<Project>.Filter.Empty;
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(Guid projectId)
        {
            var filter = Builders<Project>.Filter.Eq(c => c.Id, projectId);
            var projects = await _collection.FindAsync(filter);
            return await projects.FirstAsync();
        }

        public Project GetById(Guid projectId)
        {
            var filter = Builders<Project>.Filter.Eq(c => c.Id, projectId);
            return _collection.Find(filter).First();
        }

        public void Save(Project project)
        {
            var filter = Builders<Project>.Filter.Eq(c => c.Id, project.Id);
            _collection.ReplaceOne(filter, project, new UpdateOptions { IsUpsert = true });
        }
    }
}
