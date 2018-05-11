using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read;

namespace Read.DataCollectors
{
    public class DataCollectors : ExtendedReadModelRepositoryFor<DataCollector>,
        IDataCollectors
    {
        public DataCollectors(IMongoDatabase database)
            : base(database, database.GetCollection<DataCollector>("DataCollectors"))
        {
        }

        public DataCollector GetById(Guid id)
        {
            return _collection.Find(d => d.DataCollectorId == id).SingleOrDefault();
        }

        public async Task<DataCollector> GetByIdAsync(Guid id)
        {
            return (await _collection.FindAsync(d => d.DataCollectorId == id)).SingleOrDefault();
        }

        public IEnumerable<DataCollector> GetAll()
        {
            return _collection.Find(_ => true).ToEnumerable();
        }

        public async Task<IEnumerable<DataCollector>> GetAllAsync()
        {
            return (await _collection.FindAsync(_ => true)).ToList();
        }
    }
}
