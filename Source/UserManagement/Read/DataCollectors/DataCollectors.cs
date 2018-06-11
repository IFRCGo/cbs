using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
using Concepts.DataCollector;
using Infrastructure.Read.MongoDb;

namespace Read.DataCollectors
{
    public class DataCollectors : ExtendedReadModelRepositoryFor<DataCollector>,
        IDataCollectors
    {
        public DataCollectors(IMongoDatabase database)
            : base(database, database.GetCollection<DataCollector>("DataCollectors"))
        {
        }

        public DataCollector GetById(DataCollectorId id)
        {
            return GetOne(d => d.Id == id);
        }

        public Task<DataCollector> GetByIdAsync(DataCollectorId id)
        {
            return GetOneAsync(d => d.Id == id);
        }

        public IEnumerable<DataCollector> GetAll()
        {
            return GetMany(_ => true);
        }

        public Task<IEnumerable<DataCollector>> GetAllAsync()
        {
            return GetManyAsync(_ => true);
        }
    }
}
