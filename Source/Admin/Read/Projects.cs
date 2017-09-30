using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Read
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

        public Project GetById(Guid id)
        {
            return new Project() { Name = "Dummy implementation", Id = Guid.Empty };
        }

        public void Save(Project project)
        {
            
        }
    }
}
