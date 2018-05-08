using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dolittle.ReadModels;
using MongoDB.Driver;

namespace Read
{
    public class GenericReadModelRepositoryFor<T, TId> : IGenericReadModelRepositoryFor<T, TId>
        where TId : IEquatable<TId>
        where T : IReadModel, IHaveReadModelIdOf<TId>
    {
        protected readonly IMongoDatabase _database;
        protected readonly IMongoCollection<T> _collection;

        public IQueryable<T> Query => _collection.AsQueryable();

        public GenericReadModelRepositoryFor(IMongoDatabase database, IMongoCollection<T> collection)
        {
            _database = database;
            _collection = collection;
        }

        public void Insert(T readModel)
        {
            _collection.InsertOne(readModel);
        }

        public void Update(T readModel)
        {
            _collection.ReplaceOne(e => e.Id.Equals(readModel.Id), readModel);
        }

        public void Delete(T readModel)
        {
            _collection.DeleteOne(e => e.Id.Equals(readModel.Id));
        }

        public T GetById(object id)
        {
            if(!(id is TId tId))
                throw new Exception("id is of illegal type");
           return _collection.FindSync(e => e.Id.Equals(tId)).SingleOrDefault();
        }

        public T Get(TId id)
        {
            return _collection.FindSync(e => e.Id.Equals(id)).SingleOrDefault();
        }

        public async Task<T> GetAsync(TId id)
        {
            return (await _collection.FindAsync(e => e.Id.Equals(id))).SingleOrDefault();
        }

        public T GetOne(FilterDefinition<T> filter)
        {
            return _collection.FindSync(filter).SingleOrDefault();
        }

        public async Task<T> GetOneAsync(FilterDefinition<T> filter)
        {
            return (await _collection.FindAsync(filter)).SingleOrDefault();
        }

        public T GetOne(Expression<Func<T, bool>> filter)
        {
            return _collection.FindSync(filter).SingleOrDefault();
        }

        public async Task<T> GetOneAsync(Expression<Func<T, bool>> filter)
        {
            return (await _collection.FindAsync(filter)).SingleOrDefault();
        }

        public IEnumerable<T> GetMany(FilterDefinition<T> filter)
        {
            return _collection.Find(filter).ToList();
        }

        public async Task<IEnumerable<T>> GetManyAsync(FilterDefinition<T> filter)
        {
            return (await _collection.FindAsync(filter)).ToList();
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> filter)
        {
            return _collection.Find(filter).ToList();
        }

        public async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> filter)
        {
            return (await _collection.FindAsync(filter)).ToList();
        }

        public void Save(T readModel)
        {
            _collection.ReplaceOne(e => e.Id.Equals(readModel.Id), readModel);
        }

        public Task SaveAsync(T readModel)
        {
            return _collection.ReplaceOneAsync(e => e.Id.Equals(readModel.Id), readModel);
        }

        public Task InsertAsync(T readModel)
        {
            return _collection.InsertOneAsync(readModel);
        }

        public Task UpdateAsync(T readModel)
        {
            return _collection.ReplaceOneAsync(e => e.Id.Equals(readModel.Id), readModel);
        }

        public Task DeleteAsync(T readModel)
        {
            return _collection.DeleteOneAsync(e => e.Id.Equals(readModel.Id));
        }

        public ReplaceOneResult ReplaceOne(T readModel)
        {
            return _collection.ReplaceOne(e => e.Id.Equals(readModel.Id), readModel);
        }

        public Task<ReplaceOneResult> ReplaceOneAsync(T readModel)
        {
            return _collection.ReplaceOneAsync(e => e.Id.Equals(readModel.Id), readModel);
        }

        public UpdateResult UpdateOne(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update)
        {
            return _collection.UpdateOne(predicate, update);
        }

        public UpdateResult UpdateOne(FilterDefinition<T> predicate, UpdateDefinition<T> update)
        {
            return _collection.UpdateOne(predicate, update);
        }

        public Task<UpdateResult> UpdateOneAsync(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update)
        {
            return _collection.UpdateOneAsync(predicate, update);
        }

        public Task<UpdateResult> UpdateOneAsync(FilterDefinition<T> predicate, UpdateDefinition<T> update)
        {
            return _collection.UpdateOneAsync(predicate, update);
        }

        public UpdateResult UpdateMany(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update)
        {
            return _collection.UpdateMany(predicate, update);
        }

        public UpdateResult UpdateMany(FilterDefinition<T> predicate, UpdateDefinition<T> update)
        {
            return _collection.UpdateMany(predicate, update);
        }

        public Task<UpdateResult> UpdateManyAsync(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update)
        {
            return _collection.UpdateManyAsync(predicate, update);
        }

        public Task<UpdateResult> UpdateManyAsync(FilterDefinition<T> predicate, UpdateDefinition<T> update)
        {
            return _collection.UpdateManyAsync(predicate, update);
        }

        public DeleteResult DeleteOne(TId id)
        {
            return _collection.DeleteOne(e => e.Id.Equals(id));
        }

        public Task<DeleteResult> DeleteOneAync(TId id)
        {
            return _collection.DeleteOneAsync(e => e.Id.Equals(id));
        }

        public DeleteResult DeleteOne(Expression<Func<T, bool>> predicate)
        {
            return _collection.DeleteOne(predicate);
        }

        public DeleteResult DeleteOne(FilterDefinition<T> predicate)
        {
            return _collection.DeleteOne(predicate);
        }

        public Task<DeleteResult> DeleteOneAsync(Expression<Func<T, bool>> predicate)
        {
            return _collection.DeleteOneAsync(predicate);
        }

        public Task<DeleteResult> DeleteOneAsync(FilterDefinition<T> predicate)
        {
            return _collection.DeleteOneAsync(predicate);
        }

        public DeleteResult DeleteMany(Expression<Func<T, bool>> predicate)
        {
            return _collection.DeleteMany(predicate);
        }

        public DeleteResult DeleteMany(FilterDefinition<T> predicate)
        {
            return _collection.DeleteMany(predicate);
        }

        public Task<DeleteResult> DeleteManyAsync(Expression<Func<T, bool>> predicate)
        {
            return _collection.DeleteManyAsync(predicate);
        }

        public Task<DeleteResult> DeleteManyAsync(FilterDefinition<T> predicate)
        {
            return _collection.DeleteManyAsync(predicate);
        }
    }
}