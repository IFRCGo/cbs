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
            var project = _collection.Find(v => v.Id == id).SingleOrDefault();
            if (project == null)
            {
                project = new Project() { Name = "Dummy implementation", Id = Guid.Empty };
                _collection.InsertOne(project);
            }
            return project;
        }

        public void Save(Project project)
        {
            var filter = Builders<Project>.Filter.Eq(v => v.Id, project.Id);
            _collection.ReplaceOne(filter, project);
        }
    }
}
