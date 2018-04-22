using System.Collections.Generic;
using System.Linq;
using Dolittle.Queries;
using MongoDB.Driver;
using Read.StaffUsers.Models;

namespace Read.StaffUsers
{
    public class AllStaffUsers<T> : IQueryFor<T> 
        where T : BaseUser
    {
        private readonly IMongoCollection<BaseUser> _collection;

        public AllStaffUsers(IMongoDatabase database)
        {
            _collection = database.GetCollection<BaseUser>("StaffUsers");

        }

        public IEnumerable<T> Query => 
            _collection.FindSync(Builders<BaseUser>.Filter.OfType<T>()).ToList().Cast<T>();

    }

    public class AllStaffUsersAsync<T> : IQueryFor<T>
        where T : BaseUser
    {
        private readonly IMongoCollection<BaseUser> _collection;

        public AllStaffUsersAsync(IMongoDatabase database)
        {
            _collection = database.GetCollection<BaseUser>("StaffUsers");

        }

        public IEnumerable<T> Query =>
            _collection.FindAsync(Builders<BaseUser>.Filter.OfType<T>()).Result.ToList().Cast<T>(); //TODO: Safe?
    }
}