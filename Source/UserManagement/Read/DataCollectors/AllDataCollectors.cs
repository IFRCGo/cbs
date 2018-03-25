using System.Collections.Generic;
using System.Linq;
using doLittle.Read;
using MongoDB.Driver;

namespace Read.DataCollectors
{
    public class AllDataCollectors : IQueryFor<DataCollector>
    {
        private readonly IMongoCollection<DataCollector> _collection;

        public AllDataCollectors(IMongoDatabase database)
        {
            _collection = database.GetCollection<DataCollector>("DataCollectors");

        }

        public IEnumerable<DataCollector> Query => _collection.FindSync(_ => true).ToList();
        
    }

    public class AllDataCollectorsAsync : IQueryFor<DataCollector>
    {
        private readonly IMongoCollection<DataCollector> _collection;

        public AllDataCollectorsAsync(IMongoDatabase database)
        {
            _collection = database.GetCollection<DataCollector>("DataCollectors"); ;

        }

        public IEnumerable<DataCollector> Query => _collection.FindAsync(_ => true).Result.ToList(); //TODO: Safe?
    }

}