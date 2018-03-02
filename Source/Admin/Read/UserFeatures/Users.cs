/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Read.UserFeatures
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
            var user = _collection.Find(v => v.Id == id).SingleOrDefault();

            if (user == null)
            {
                user = new User {Id = id, Firstname = "Dummy implementation"};
                _collection.InsertOne(user);
            }

            return user;
        }

        public async Task<IEnumerable<User>> GetByNationalSocietyId(Guid id)
        {
            var userList = await _collection.FindAsync(_ => _.NationalSocietyId == id);
            return await userList.ToListAsync();
        }

        public void Save(User user)
        {
            var filter = Builders<User>.Filter.Eq(v => v.Id, user.Id);

            _collection.ReplaceOne(filter, user);
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