using System.Collections.Generic;
using doLittle.Read;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Read.GreetingGenerators;
using Read.StaffUsers.Models;

namespace Read.StaffUsers
{
    //TODO: Question. Seperate query for each kind of staffuser, or use a generic one like this?
    public class AllStaffUsers<T> : IQueryFor<T> 
        where T : BaseUser
    {
        private readonly IMongoCollection<BaseUser> _collection;

        public AllStaffUsers(IMongoCollection<BaseUser> collection)
        {
            _collection = collection;

        }

        public StaffUserIAsyncCursor<T> Query => new StaffUserIAsyncCursor<T>(_collection.FindSync(Builders<BaseUser>.Filter.OfType<T>()));

    }

    public class AllStaffUsersAsync<T> : IQueryFor<T>
        where T : BaseUser
    {
        private readonly IMongoCollection<BaseUser> _collection;

        public AllStaffUsersAsync(IMongoCollection<BaseUser> collection)
        {
            _collection = collection;

        }

        public StaffUserIAsyncCursor<T> Query =>
            new StaffUserIAsyncCursor<T>(_collection.FindAsync(Builders<BaseUser>.Filter.OfType<T>()).Result); //TODO: Safe?
    }
}