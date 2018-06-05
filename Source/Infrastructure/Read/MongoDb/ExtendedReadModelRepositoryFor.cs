using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Dolittle.Concepts;
using Dolittle.ReadModels;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Read.MongoDb
{
    /// <summary>
    /// An implementation of IReadModelFor\<<typeparamref name="T"/>\>.
    /// Gives a common set of operations on IReadModel in an IMongoCollection.
    /// 
    /// Assumes that the ReadModels have defined an BsonId field with name _id, which is default.
    /// </summary>
    /// <typeparam name="T">The ReadModel</typeparam>
    public class ExtendedReadModelRepositoryFor<T> : IExtendedReadModelRepositoryFor<T>
        where T : IReadModel
    {
        protected readonly IMongoDatabase _database;
        protected readonly IMongoCollection<T> _collection;

        public IQueryable<T> Query => _collection.AsQueryable();

        public ExtendedReadModelRepositoryFor(IMongoDatabase database, IMongoCollection<T> collection)
        {
            _database = database;
            _collection = collection;
        }

        public void Insert(T readModel)
        {
            _collection.InsertOne(readModel);
        }

        public Task InsertAsync(T readModel)
        {
            return _collection.InsertOneAsync(readModel);
        }

        #region Get

        public T GetById(object id)
        {
            var filter = Builders<T>.Filter.Eq("_id", GetIdAsBsonValue(id));
            return _collection.FindSync(filter).FirstOrDefault();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            var filter = Builders<T>.Filter.Eq("_id", GetIdAsBsonValue(id));
            return (await _collection.FindAsync(filter)).FirstOrDefault();
        }

        public T GetOne(FilterDefinition<T> filter)
        {
            return _collection.FindSync(filter).FirstOrDefault();
        }

        public async Task<T> GetOneAsync(FilterDefinition<T> filter)
        {
            return (await _collection.FindAsync(filter)).FirstOrDefault();
        }

        public T GetOne(Expression<Func<T, bool>> filter)
        {
            return _collection.FindSync(filter).FirstOrDefault();
        }

        public async Task<T> GetOneAsync(Expression<Func<T, bool>> filter)
        {
            return (await _collection.FindAsync(filter)).FirstOrDefault();
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

        #endregion

        #region Save

        public void Save(T readModel)
        {
            var id = GetObjectIdFromReadModel(readModel);
            var filter = Builders<T>.Filter.Eq("_id", id);
            _collection.ReplaceOne(filter, readModel, new UpdateOptions() { IsUpsert = true });
        }

        public void Update(T readModel, object id)
        {
            var filter = Builders<T>.Filter.Eq("_id", GetIdAsBsonValue(id));
            _collection.ReplaceOne(filter, readModel, new UpdateOptions() { IsUpsert = true });
        }

        public void Update(T readModel, FilterDefinition<T> filter)
        {

            _collection.ReplaceOne(filter, readModel, new UpdateOptions() { IsUpsert = true });
        } 

        public void Update(T readModel, Expression<Func<T, bool>> filter)
        {
            _collection.ReplaceOne(filter, readModel, new UpdateOptions() { IsUpsert = true });
        }

        public Task SaveAsync(T readModel)
        {
            var id = GetObjectIdFromReadModel(readModel);
            var filter = Builders<T>.Filter.Eq("_id", id);
            return _collection.ReplaceOneAsync(filter, readModel, new UpdateOptions() { IsUpsert = true });
        }

        public Task UpdateAsync(T readModel, object id)
        {
            var filter = Builders<T>.Filter.Eq("_id", GetIdAsBsonValue(id));
           return _collection.ReplaceOneAsync(filter, readModel, new UpdateOptions() { IsUpsert = true });
        }

        public Task UpdateAsync(T readModel, FilterDefinition<T> filter)
        {
            return _collection.ReplaceOneAsync(filter, readModel, new UpdateOptions() { IsUpsert = true });
        }

        public Task UpdateAsync(T readModel, Expression<Func<T, bool>> filter)
        {
            return _collection.ReplaceOneAsync(filter, readModel, new UpdateOptions() { IsUpsert = true });
        }

        #endregion

        #region Replace

        public ReplaceOneResult ReplaceOne(T readModel)
        {
            var id = GetObjectIdFromReadModel(readModel);
            var filter = Builders<T>.Filter.Eq("_id", id);
            return _collection.ReplaceOne(filter, readModel, new UpdateOptions() { IsUpsert = true });
        }

        public ReplaceOneResult ReplaceOne(T readModel, object id)
        {
            var filter = Builders<T>.Filter.Eq("_id", GetIdAsBsonValue(id));
            return _collection.ReplaceOne(filter, readModel, new UpdateOptions() { IsUpsert = true });
        }

        public ReplaceOneResult ReplaceOne(T readModel, FilterDefinition<T> filter)
        {
            return _collection.ReplaceOne(filter, readModel, new UpdateOptions() { IsUpsert = true });
        }

        public ReplaceOneResult ReplaceOne(T readModel, Expression<Func<T, bool>> filter)
        {
            return _collection.ReplaceOne(filter, readModel, new UpdateOptions() { IsUpsert = true });
        }

        public Task<ReplaceOneResult> ReplaceOneAsync(T readModel)
        {
            var id = GetObjectIdFromReadModel(readModel);
            var filter = Builders<T>.Filter.Eq("_id", id);
            return _collection.ReplaceOneAsync(filter, readModel, new UpdateOptions() { IsUpsert = true });
        }

        public Task<ReplaceOneResult> ReplaceOneAsync(T readModel, object id)
        {
            var filter = Builders<T>.Filter.Eq("_id", GetIdAsBsonValue(id));
            return _collection.ReplaceOneAsync(filter, readModel, new UpdateOptions() { IsUpsert = true });
        }

        public Task<ReplaceOneResult> ReplaceOneAsync(T readModel, FilterDefinition<T> filter)
        {
            return _collection.ReplaceOneAsync(filter, readModel, new UpdateOptions() { IsUpsert = true });
        }

        public Task<ReplaceOneResult> ReplaceOneAsync(T readModel, Expression<Func<T, bool>> filter)
        {
            return _collection.ReplaceOneAsync(filter, readModel, new UpdateOptions() { IsUpsert = true });
        }

        #endregion

        #region Update

        public void Update(T readModel)
        {
            var id = GetObjectIdFromReadModel(readModel);
            var filter = Builders<T>.Filter.Eq("_id", id);
            _collection.ReplaceOne(filter, readModel, new UpdateOptions() { IsUpsert = true });
        }

        public Task UpdateAsync(T readModel)
        {
            var id = GetObjectIdFromReadModel(readModel);
            var filter = Builders<T>.Filter.Eq("_id", id);
            return _collection.ReplaceOneAsync(filter, readModel, new UpdateOptions() { IsUpsert = true });
        }

        public void UpdateAsync(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update)
        {
            _collection.UpdateMany(predicate, update);
        }

        public void UpdateAsync(FilterDefinition<T> predicate, UpdateDefinition<T> update)
        {
            _collection.UpdateMany(predicate, update);
        }

        public Task UpdateAsync(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update)
        {
            return _collection.UpdateManyAsync(predicate, update);
        }

        public Task UpdateAsync(FilterDefinition<T> predicate, UpdateDefinition<T> update)
        {
            return _collection.UpdateManyAsync(predicate, update);
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

        #endregion

        #region Delete

        public void Delete(T readModel)
        {
            var id = GetObjectIdFromReadModel(readModel);
            var filter = Builders<T>.Filter.Eq("_id", id);
            _collection.DeleteOne(filter);
        }

        public Task DeleteAsync(T readModel)
        {
            var id = GetObjectIdFromReadModel(readModel);
            var filter = Builders<T>.Filter.Eq("_id", id);
            return _collection.DeleteOneAsync(filter);
        }

        public void Delete(object id)
        {
            var filter = Builders<T>.Filter.Eq("_id", GetIdAsBsonValue(id));
            _collection.DeleteOne(filter);
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            _collection.DeleteMany(predicate);
        }

        public void Delete(FilterDefinition<T> predicate)
        {
            _collection.DeleteMany(predicate);
        }

        public Task DeleteAsync(object id)
        {
            var filter = Builders<T>.Filter.Eq("_id", GetIdAsBsonValue(id));
            return _collection.DeleteOneAsync(filter);
        }

        public Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            return _collection.DeleteManyAsync(predicate);
        }

        public Task DeleteAsync(FilterDefinition<T> predicate)
        {
            return _collection.DeleteManyAsync(predicate);
        }

        public DeleteResult DeleteOne(object id)
        {
            var filter = Builders<T>.Filter.Eq("_id", GetIdAsBsonValue(id));
            return _collection.DeleteOne(filter);
        }

        public DeleteResult DeleteOne(Expression<Func<T, bool>> predicate)
        {
            return _collection.DeleteOne(predicate);
        }

        public DeleteResult DeleteOne(FilterDefinition<T> predicate)
        {
            return _collection.DeleteOne(predicate);
        }

        public Task<DeleteResult> DeleteOneAsync(object id)
        {
            var filter = Builders<T>.Filter.Eq("_id", GetIdAsBsonValue(id));
            return _collection.DeleteOneAsync(filter);
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

        #endregion

        // This part is copied from https://github.com/dolittle-extensions/ReadModels.MongoDB/blob/master/Source/ReadModelRepositoryFor.cs
        public BsonValue GetObjectIdFromReadModel(T readModel)
        {
            return GetObjectIdFrom(readModel);
        }

        private BsonValue GetObjectIdFrom(T entity)
        {
            try
            {
                var propInfo = GetIdProperty(entity);
                object id = propInfo.GetValue(entity);

                return GetIdAsBsonValue(id);
            }
            catch (InvalidOperationException)
            {
                var bsonDocument = entity.ToBsonDocument();
                return bsonDocument["_id"];
            }
            catch (Exception e) //TODO: Change to catch explicit Exceptions when I know what kind exception this might throw
            {
                var type = entity.GetType();
                throw new ReadModelHasNoIdField(
                    $"Type {type.FullName} does not provide a BSon Class Mapping for _id",
                    e
                );
            }
        }

        private BsonValue GetIdAsBsonValue(object id)
        {
            var idVal = id;
            if (id.IsConcept())
                idVal = id.GetConceptValue();

            var idAsValue = BsonValue.Create(idVal);
            return idAsValue;
        }

        private PropertyInfo GetIdProperty(T entity)
        {
            return typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).First(p => p.Name.ToLowerInvariant() == "id");
        }
    }
}