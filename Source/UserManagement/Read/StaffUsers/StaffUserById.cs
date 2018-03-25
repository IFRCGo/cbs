using System;
using doLittle.Read;
using MongoDB.Driver;
using Read.StaffUsers.Models;

namespace Read.StaffUsers
{
    //TODO: Question. Seperate query for each kind of staffuser, or use a generic one like this?
    public class StaffUserById<T> : IQueryFor<T>
        where T : BaseUser
    {
        private readonly IMongoCollection<BaseUser> _collection;

        public StaffUserById(IMongoCollection<BaseUser> collection, Guid staffUserId)
        {
            _collection = collection;
            StaffUserId = staffUserId;

        }

        public Guid StaffUserId { get; }
        public StaffUserIAsyncCursor<T> Query =>
            new StaffUserIAsyncCursor<T>(_collection.FindSync(u => u.StaffUserId == StaffUserId));

    }

    public class StaffUserByIdAsync<T> : IQueryFor<T>
        where T : BaseUser
    {
        private readonly IMongoCollection<BaseUser> _collection;

        public StaffUserByIdAsync(IMongoCollection<BaseUser> collection, Guid staffUserId)
        {
            _collection = collection;
            StaffUserId = staffUserId;

        }

        public Guid StaffUserId { get; }
        public StaffUserIAsyncCursor<T> Query =>
            new StaffUserIAsyncCursor<T>(_collection.FindAsync(u => u.StaffUserId == StaffUserId).Result); //TODO: Safe?
    }
}