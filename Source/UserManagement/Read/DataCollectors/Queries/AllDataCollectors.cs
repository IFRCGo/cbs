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
        readonly IDataCollectorMigrator _migrator;
        public AllDataCollectors(IDataCollectors repository, IDataCollectorMigrator migrator)
        {
            _repository = repository;
            _migrator = migrator;
        }

        public IQueryable<DataCollector> Query 
        { 
            get 
            {
                var queryAsEnumerable = _repository.Query.AsEnumerable();
                IList<DataCollector> dataCollectors = new List<DataCollector>();

                foreach (var item in queryAsEnumerable)
                {
                    dataCollectors.Add(_migrator.Migrate(item));
                }
                return dataCollectors.AsQueryable();
            }
        }
        
    }
}