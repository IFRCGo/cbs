using System.Linq;
using Concepts.DataCollectors;
using Dolittle.Queries;

namespace Read.DataCollectors
{
    public class DataCollectorById : IQueryFor<DataCollector>
    {
        readonly IDataCollectors _repository;

        public DataCollectorId DataCollectorId { get; set; }

        public DataCollectorById(IDataCollectors repository)
        {
            _repository = repository;
        }
        
        public IQueryable<DataCollector> Query => _repository.Query.Where(d => d.Id == DataCollectorId);
    }
}