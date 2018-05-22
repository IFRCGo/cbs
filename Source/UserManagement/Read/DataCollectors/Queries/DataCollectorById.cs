using System;
using System.Linq;
using Dolittle.Queries;

namespace Read.DataCollectors.Queries
{
    public class DataCollectorById : IQueryFor<DataCollector>
    {
        private readonly IDataCollectors _repository;

        public Guid DataCollectorId { get; set; }

        public DataCollectorById(IDataCollectors repository)
        {
            _repository = repository;
        }
        
        public IQueryable<DataCollector> Query => _repository.Query.Where(d => d.Id == DataCollectorId);
    }
}