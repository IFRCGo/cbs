using System.Linq;
using Dolittle.Queries;

namespace Read.DataCollectors.Queries
{
    public class AllDataCollectors : IQueryFor<DataCollector>
    {
        private readonly IDataCollectors _repository;

        public AllDataCollectors(IDataCollectors repository)
        {
            _repository = repository;
        }

        public IQueryable<DataCollector> Query => _repository.Query;
        
    }
}