using System.Collections.Generic;
using System.Linq;
using doLittle.Read;
using MongoDB.Driver;

namespace Read.DataCollectors
{
    public class AllDataCollectors : IQueryFor<DataCollector>
    {
        private readonly IMongoCollection<DataCollector> _collection;

        public PagingInfo PagingInfo { get; set; }

        public AllDataCollectors(IMongoCollection<DataCollector> collection)
        {
            _collection = collection;

        }

        public IAsyncCursor<DataCollector> Query => _collection.FindSync(_ => true);
        
    }

    public class AllDataCollectorsAsync : IQueryFor<DataCollector>
    {
        private readonly IMongoCollection<DataCollector> _collection;

        public AllDataCollectorsAsync(IMongoCollection<DataCollector> collection)
        {
            _collection = collection;

        }

        public PagingInfo PagingInfo { get; set; }

        public IAsyncCursor<DataCollector> Query => _collection.FindAsync(_ => true).Result; //TODO: Safe?
    }

}