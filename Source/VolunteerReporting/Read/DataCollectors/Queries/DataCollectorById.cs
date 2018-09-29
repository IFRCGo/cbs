using System;
using System.Linq;
using Concepts;
using Concepts.DataCollector;
using Dolittle.Queries;

namespace Read.DataCollectors.Queries
{
    public class DataCollectorById : IQueryFor<DataCollector>
    {
        private readonly IDataCollectors _collection;

        public DataCollectorId DataCollectorId { get; set; }

        public DataCollectorById(IDataCollectors collection)
        {
            _collection = collection;
        }

        public IQueryable<DataCollector> Query => _collection.Query.Where(d => d.Id == DataCollectorId);
    }
}