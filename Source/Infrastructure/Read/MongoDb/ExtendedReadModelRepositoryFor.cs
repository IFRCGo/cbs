using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        /// <summary>
        /// CosmosDb is apparently not liking it when we are not filtering the queries...
        /// When using this, be sure to define a Where-clause or sommething.
        /// </summary>
        /// <returns></returns>
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

        public void Insert(T readModel)
        {
            _collection.InsertOne(readModel);
        }

        public void Update(T readModel)
        {
            var id = GetObjectIdFromReadModel(readModel);
            var filter = Builders<T>.Filter.Eq("_id", id);
            _collection.ReplaceOne(filter, readModel, new UpdateOptions() { IsUpsert = true });
        }

        public void Delete(T readModel)
        {
            var id = GetObjectIdFromReadModel(readModel);
            var filter = Builders<T>.Filter.Eq("_id", id);
            _collection.DeleteOne(filter);
        }

        #region Get

        public T GetOne(FilterDefinition<T> filter)
        {
            return _collection.FindSync(filter).FirstOrDefault();
        }

        public T GetOne(Expression<Func<T, bool>> filter)
        {
            return _collection.FindSync(filter).FirstOrDefault();
        }

        public IEnumerable<T> GetMany(FilterDefinition<T> filter)
        {
            return _collection.Find(filter).ToEnumerable();
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> filter)
        {
            return _collection.Find(filter).ToEnumerable();
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

        #endregion
        
        static BsonValue GetObjectIdFromReadModel(T readModel)
        {
            return GetObjectIdFrom(readModel);
        }

        static BsonValue GetObjectIdFrom(T entity)
        {
            try
            {
                var bsonDocument = entity.ToBsonDocument();
                return bsonDocument["_id"];
            }
            catch (Exception)
            {
                var type = entity.GetType();
                throw new NoBsonClassMapRegistered(
                    $"Type {type.FullName} has no BsonClassMap registered that has an _id field"
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
        
    }
}