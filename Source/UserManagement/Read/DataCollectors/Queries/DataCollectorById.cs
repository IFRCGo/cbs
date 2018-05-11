using System;
using System.Linq;
using Dolittle.Queries;

namespace Read.DataCollectors.Queries
{
    public class DataCollectorById : IQueryFor<DataCollector>
    {
        private readonly IDataCollectors _repository;

        public Guid DataCollectorId { get; set; }

        public DataCollectorById(IDataCollectors repository, Guid dataCollectorId)
        {
            _repository = repository;
            DataCollectorId = dataCollectorId;
        }
        
        public IQueryable<DataCollector> Query => _repository.GetMany(d => d.DataCollectorId == DataCollectorId).AsQueryable();
    }
}