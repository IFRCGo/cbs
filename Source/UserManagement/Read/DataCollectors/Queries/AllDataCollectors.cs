using System.Collections.Generic;
using System.Linq;
using Dolittle.Collections;
using Dolittle.Queries;
using Infrastructure.Read.MongoDb;
using Read.DataCollectors.Migration;

namespace Read.DataCollectors.Queries
{
    public class AllDataCollectors : IQueryFor<DataCollector>
    {
        readonly IDataCollectors _repository;
        public AllDataCollectors(IDataCollectors repository)
        {
            _repository = repository;
        }

        public IQueryable<DataCollector> Query => _repository.Query;
        
    }
}