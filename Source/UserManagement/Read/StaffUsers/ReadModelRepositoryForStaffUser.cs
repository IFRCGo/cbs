using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using Read.StaffUsers.Models;

namespace Read.StaffUsers
{
    public abstract class ReadModelRepositoryForStaffUser<TUser> : IReadModelRepositoryForStaffUser<TUser>
        where TUser : BaseUser
    {
        public IQueryable<TUser> Query => _collection.AsQueryable();

        protected readonly IMongoDatabase _database;

        protected readonly IMongoCollection<TUser> _collection;

        protected ReadModelRepositoryForStaffUser(IMongoDatabase database, IMongoCollection<TUser> collection)
        {
            _database = database;
            _collection = collection;
        }

        public void Insert(TUser readModel)
        {
            _collection.InsertOne(readModel);
        }

        public Task InsertAsync(TUser readModel)
        {
            return _collection.InsertOneAsync(readModel);
        }

        public void Update(TUser readModel)
        {
            var res = _collection.ReplaceOne(_ => _.StaffUserId == readModel.StaffUserId, readModel, new UpdateOptions { IsUpsert = false });

            if (res.MatchedCount < 1)
                throw new UserNotFound("Admin with StaffUserId " + readModel.StaffUserId + " was not found");
        }

        public void Delete(TUser readModel)
        {
            _collection.DeleteOne(_ => _.StaffUserId == readModel.StaffUserId);
        }

        public TUser GetById(object staffUserId)
        {
            if (!(staffUserId is Guid)) throw new ArgumentException("Id must be Guid");
            return _collection.Find(_ => _.StaffUserId == (Guid)staffUserId).FirstOrDefault();
        }

        
        public TUser Get(Guid staffUserId)
        {
            return _collection.Find(_ => _.StaffUserId == staffUserId).FirstOrDefault();
        }

        public async Task<TUser> GetAsync(Guid staffUserId)
        {
            return (await _collection.FindAsync(_ => _.StaffUserId == staffUserId)).FirstOrDefault();
        }
        
        public Task UpdateAsync(TUser readModel)
        {
            return _collection.ReplaceOneAsync(_ => _.StaffUserId == readModel.StaffUserId, readModel);
        }

        public Task DeleteAsync(TUser readModel)
        {
            return _collection.DeleteOneAsync(_ => _.StaffUserId == readModel.StaffUserId);
        }

        public UpdateResult UpdateOne(Expression<Func<TUser, bool>> predicate, UpdateDefinition<TUser> update)
        {
            return _collection.UpdateOne(predicate, update);
        }

        public UpdateResult UpdateOne(FilterDefinition<TUser> predicate, UpdateDefinition<TUser> update)
        {
            return _collection.UpdateOne(predicate, update);
        }

        public Task<UpdateResult> UpdateOneAsync(Expression<Func<TUser, bool>> predicate, UpdateDefinition<TUser> update)
        {
            return _collection.UpdateOneAsync(predicate, update);
        }

        public Task<UpdateResult> UpdateOneAsync(FilterDefinition<TUser> predicate, UpdateDefinition<TUser> update)
        {
            return _collection.UpdateOneAsync(predicate, update);
        }

        public UpdateResult UpdateMany(Expression<Func<TUser, bool>> predicate, UpdateDefinition<TUser> update)
        {
            return _collection.UpdateMany(predicate, update);
        }

        public UpdateResult UpdateMany(FilterDefinition<TUser> predicate, UpdateDefinition<TUser> update)
        {
            return _collection.UpdateMany(predicate, update);
        }

        public Task<UpdateResult> UpdateManyAsync(Expression<Func<TUser, bool>> predicate, UpdateDefinition<TUser> update)
        {
            return _collection.UpdateManyAsync(predicate, update);
        }

        public Task<UpdateResult> UpdateManyAsync(FilterDefinition<TUser> predicate, UpdateDefinition<TUser> update)
        {
            return _collection.UpdateManyAsync(predicate, update);
        }

        public UpdateResult ChangeBaseUserInformation(Guid staffUserId, string fullName, string displayName, string email)
        {
            var updateFullName = Builders<TUser>.Update.Set(a => a.FullName, fullName);
            var updateDisplayName = Builders<TUser>.Update.Set(a => a.DisplayName, displayName);
            var updateEmail = Builders<TUser>.Update.Set(a => a.Email, email);

            return UpdateOne(
                a => a.StaffUserId == staffUserId,
                Builders<TUser>.Update.Combine(updateFullName, updateDisplayName, updateEmail));
        }

        public Task<UpdateResult> ChangeBaseUserInformationAsync(Guid staffUserId, string fullName, string displayName, string email)
        {
            var updateFullName = Builders<TUser>.Update.Set(a => a.FullName, fullName);
            var updateDisplayName = Builders<TUser>.Update.Set(a => a.DisplayName, displayName);
            var updateEmail = Builders<TUser>.Update.Set(a => a.Email, email);

            return UpdateOneAsync(
                a => a.StaffUserId == staffUserId,
                Builders<TUser>.Update.Combine(updateFullName, updateDisplayName, updateEmail));
        }
    }
}