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
    }
}
