// /*---------------------------------------------------------------------------------------------
//  *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
//  *  Licensed under the MIT License. See LICENSE in the project root for license information.
//  *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Read
{
    public class Users : IUsers
    {
        readonly IMongoCollection<User> _collection;

        readonly IMongoDatabase _database;

        public Users(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<User>("User");
        }

        public User GetById(Guid id)
        {
            var project = _collection.Find(v => v.Id == id).SingleOrDefault();

            if (project == null)
            {
                project = new User { Firstname = "Dummy implementation"};
                _collection.InsertOne(project);
            }

            return project;
        }

        public void Save(User project)
        {
            var filter = Builders<User>.Filter.Eq(v => v.Id, project.Id);

            _collection.ReplaceOne(filter, project);
        }

        public IEnumerable<User> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        public async Task<IEnumerable<User>> GetAllASync()
        {
            var filter = Builders<User>.Filter.Empty;
            var list = await _collection.FindAsync(filter);

            return await list.ToListAsync();
        }
    }
}