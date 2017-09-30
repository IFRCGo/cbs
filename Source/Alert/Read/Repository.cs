using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace Read
{
    public class Repository<T> where T : Entity
    {
        private readonly IMongoCollection<T> _collection;

        public Repository(IMongoCollection<T> collection)
        {
            _collection = collection;
        }

        public T GetById(Guid id)
        {
            return _collection.Find(c => c.Id == id).SingleOrDefault();
        }

        public void Save(T entity)
        {
            var filter = Builders<T>.Filter.Eq(c => c.Id, entity.Id);
            _collection.ReplaceOne(filter, entity);
        }
    }
}
