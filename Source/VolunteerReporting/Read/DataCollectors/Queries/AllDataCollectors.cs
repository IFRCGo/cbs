using System.Linq;
using Dolittle.Queries;

namespace Read.DataCollectors.Queries
{
    public class AllDataCollectors : IQueryFor<DataCollector>
    {
        private readonly IDataCollectors _collection;

        public AllDataCollectors(IDataCollectors collection)
        {
            _collection = collection;
        }

        public IQueryable<DataCollector> Query => _collection.Query.Where(_ => true);
    }
}