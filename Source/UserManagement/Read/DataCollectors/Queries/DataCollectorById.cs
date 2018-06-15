using System;
using System.Collections.Generic;
using System.Linq;
using Dolittle.Queries;
using Read.DataCollectors.Migration;
using Infrastructure.Read.MongoDb;

namespace Read.DataCollectors.Queries
{
    public class DataCollectorById : IQueryFor<DataCollector>
    {
        readonly IDataCollectors _repository;
        readonly IDataCollectorMigrator _migrator;

        public Guid DataCollectorId { get; set; }

        public DataCollectorById(IDataCollectors repository, IDataCollectorMigrator migrator)
        {
            _repository = repository;
            _migrator = migrator;
        }
        
        public IQueryable<DataCollector> Query => _repository.Query.Where(d => d.Id == DataCollectorId);
    }
}