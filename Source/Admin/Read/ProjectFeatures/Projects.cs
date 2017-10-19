/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Read.ProjectFeatures
{
    public class Projects : IProjects
    {
        readonly IMongoCollection<Project> _collection;

        readonly IMongoDatabase _database;

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
                project = new Project {Name = "Dummy implementation"};
                _collection.InsertOne(project);
            }
            return project;
        }

        public void Save(Project project)
        {
            var filter = Builders<Project>.Filter.Eq(v => v.Id, project.Id);
            _collection.ReplaceOne(filter, project);
        }

        public IEnumerable<Project> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        public async Task<IEnumerable<Project>> GetAllASync()
        {
            var filter = Builders<Project>.Filter.Empty;
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }
    }
}