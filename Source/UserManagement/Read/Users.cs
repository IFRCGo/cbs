using System;
using MongoDB.Driver;

namespace Read
{
    public class Users : IUsers
    {
        readonly IMongoDatabase _database;
        readonly IMongoCollection<User> _collection;

        public Users(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<User>("User");
        }

        public User GetById(Guid id)
        {
            var user = _collection.Find(c => c.Id == id).SingleOrDefault();
            if( user == null ) 
            {
                user = new User { Id = id };
                _collection.InsertOne(user);
            }
            return user;
        }

        public void Save(User user)
        {
            //var filter = Builders<User>.Filter.Eq(c => c.Id, user.Id);
            _collection.InsertOne(user);
        }
    }
}