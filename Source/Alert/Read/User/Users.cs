using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace Read
{
    public class Users : Repository<User>, IUsers
    {
        public Users(IMongoCollection<User> collection) : base(collection)
        {
        }
    }
}
