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
            var cart = _collection.Find(c => c.Id == id).SingleOrDefault();
            if( cart == null ) 
            {
                cart = new User { Id = id };
                _collection.InsertOne(cart);
            }
            return cart;
        }

        public void Save(User user)
        {
            //var filter = Builders<User>.Filter.Eq(c => c.Id == user.Id);
            //_collection.ReplaceOne(filter, user);
        }

        public Guid GetCartIdForCurrentUser()
        {
            return Guid.NewGuid();
        }
    }
}