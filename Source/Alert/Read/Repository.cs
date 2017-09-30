using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace Read
{
    public class Repository<T> where T : Entity
    {
        internal readonly IMongoCollection<T> _collection;

        public Repository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        public T GetById(Guid id)
        {
            return _collection.Find(c => c.Id == id).SingleOrDefault();
        }

        public void Save(T entity)
        {
            var filter = Builders<T>.Filter.Eq(c => c.Id, entity.Id);
            _collection.ReplaceOne(filter, entity, new UpdateOptions(){IsUpsert = true});
        }
    }
}
