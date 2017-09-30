using System;
using MongoDB.Driver;

namespace Read
{
    public class Carts : ICarts
    {
        readonly IMongoDatabase _database;
        readonly IMongoCollection<Cart> _collection;

        public Carts(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<Cart>("Cart");
        }

        public Cart GetById(Guid id)
        {
            var cart = _collection.Find(c => c.Id == id).SingleOrDefault();
            if( cart == null ) 
            {
                cart = new Cart { Id = id };
                _collection.InsertOne(cart);
            }
            return cart;
        }

        public void Save(Cart cart)
        {
            var filter = Builders<Cart>.Filter.Eq(c => c.Id, cart.Id);
            _collection.ReplaceOne(filter, cart);
        }

        public Guid GetCartIdForCurrentUser()
        {
            return Guid.NewGuid();
        }
    }
}