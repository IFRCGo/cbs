using System;
using MongoDB.Driver;

namespace Read
{
    public class Carts : ICarts
    {
        public Carts() //IMongoDatabase database)
        {

        }


        public Cart GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Guid GetCartIdForCurrentUser()
        {
            return Guid.NewGuid();
        }

        public void Save(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}