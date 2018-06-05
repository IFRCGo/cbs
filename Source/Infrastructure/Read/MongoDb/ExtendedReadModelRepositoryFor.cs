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

        public void Insert(T readModel)
        {
            _collection.InsertOne(readModel);
        }
        public Task InsertAsync(T readModel)
        {
            return _collection.InsertOneAsync(readModel);
        }

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

        #region Get

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
            return _collection.Find(filter).ToEnumerable();
        }
        public async Task<IEnumerable<T>> GetManyAsync(FilterDefinition<T> filter)
        {
            return (await _collection.FindAsync(filter)).ToEnumerable();
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> filter)
        {
            return _collection.Find(filter).ToEnumerable();
        }
        public async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> filter)
        {
            return (await _collection.FindAsync(filter)).ToEnumerable();
        }

        #endregion

        #region ReplaceOne

        public ReplaceOneResult ReplaceOne(T readModel, FilterDefinition<T> filter)
        {
            return _collection.ReplaceOne(filter, readModel, new UpdateOptions { IsUpsert = true });
        }

        public ReplaceOneResult ReplaceOne(T readModel, Expression<Func<T, bool>> filter)
        {
            return _collection.ReplaceOne(filter, readModel, new UpdateOptions { IsUpsert = true });
        }

        public Task<ReplaceOneResult> ReplaceOneAsync(T readModel, FilterDefinition<T> filter)
        {
            return _collection.ReplaceOneAsync(filter, readModel, new UpdateOptions { IsUpsert = true });
        }

        public Task<ReplaceOneResult> ReplaceOneAsync(T readModel, Expression<Func<T, bool>> filter)
        {
            return _collection.ReplaceOneAsync(filter, readModel, new UpdateOptions { IsUpsert = true });
        }

        #endregion

        #region Update

        public UpdateResult Update(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update)
        {
            return _collection.UpdateMany(predicate, update);
        }

        public UpdateResult Update(FilterDefinition<T> predicate, UpdateDefinition<T> update)
        {
            return _collection.UpdateMany(predicate, update);
        }

        public Task<UpdateResult> UpdateAsync(Expression<Func<T, bool>> predicate, UpdateDefinition<T> update)
        {
            return _collection.UpdateManyAsync(predicate, update);
        }

        public Task<UpdateResult> UpdateAsync(FilterDefinition<T> predicate, UpdateDefinition<T> update)
        {
            return _collection.UpdateManyAsync(predicate, update);
        }

        #endregion

        #region Delete

        public DeleteResult Delete(Expression<Func<T, bool>> predicate)
        {
            return _collection.DeleteMany(predicate);
        }

        public DeleteResult Delete(FilterDefinition<T> predicate)
        {
            return _collection.DeleteMany(predicate);
        }

        public Task<DeleteResult> DeleteAsync(object id)
        {
            var filter = Builders<T>.Filter.Eq("_id", GetIdAsBsonValue(id));
            return _collection.DeleteManyAsync(filter);
        }

        public Task<DeleteResult> DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            return _collection.DeleteManyAsync(predicate);
        }

        public Task<DeleteResult> DeleteAsync(FilterDefinition<T> predicate)
        {
            return _collection.DeleteManyAsync(predicate);
        }

        #endregion

        // This part is copied from https://github.com/dolittle-extensions/ReadModels.MongoDB/blob/master/Source/ReadModelRepositoryFor.cs
        static BsonValue GetObjectIdFromReadModel(T readModel)
        {
            return GetObjectIdFrom(readModel);
        }

        static BsonValue GetObjectIdFrom(T entity)
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

        static BsonValue GetIdAsBsonValue(object id)
        {
            var idVal = id;
            if (id.IsConcept())
                idVal = id.GetConceptValue();

            var idAsValue = BsonValue.Create(idVal);
            return idAsValue;
        }

        static PropertyInfo GetIdProperty(T entity)
        {
            return typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).First(p => p.Name.ToLowerInvariant() == "id");
        }
    }
}