using System;
using Dolittle.Queries;
using MongoDB.Driver;
using Read.StaffUsers.Models;

namespace Read.StaffUsers
{
    public class StaffUserById<T> : IQueryFor<T>
        where T : BaseUser
    {
        private readonly IMongoCollection<BaseUser> _collection;

        public StaffUserById(IMongoDatabase database, Guid staffUserId)
        {
            _collection = database.GetCollection<BaseUser>("StaffUsers");
            StaffUserId = staffUserId;

        }

        public Guid StaffUserId { get; }

        public T Query => _collection.FindSync(u => u.StaffUserId == StaffUserId).FirstOrDefault() as T;

    }

    public class StaffUserByIdAsync<T> : IQueryFor<T>
        where T : BaseUser
    {
        private readonly IMongoCollection<BaseUser> _collection;

        public StaffUserByIdAsync(IMongoDatabase database, Guid staffUserId)
        {
            _collection = database.GetCollection<BaseUser>("StaffUsers");
            StaffUserId = staffUserId;
        }

        public Guid StaffUserId { get; }
        public T Query => 
            _collection.FindAsync(u => u.StaffUserId == StaffUserId).Result.FirstOrDefault() as T; //TODO: Safe?
    }
}