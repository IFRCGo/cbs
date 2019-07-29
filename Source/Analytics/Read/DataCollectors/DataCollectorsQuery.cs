using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;
using System.Collections.Generic;
using Concepts;

namespace Read.DataCollectors
{
    public class DataCollectorsQuery : IQuery
    {
        readonly IReadModelRepositoryFor<DataCollector> _repositoryForDataCollectors;

        
        public DataCollectorsQuery(IReadModelRepositoryFor<DataCollector> repositoryForDataCollectors){
            _repositoryForDataCollectors = repositoryForDataCollectors;
        }

        public IQueryable Query
        {
            get
            {
                var deadlineDay = DateTimeOffset.Now.AddDays(-28);
                // var result = new List<int> {(from c in _repositoryForDataCollectors.Query select c).Count(c => c.Region == "Togda")};
                //    var inactiveDataCollectors = new List<int>(){_repositoryForDataCollectors};
                 var activeDataCollectors   = _repositoryForDataCollectors.Query.Where(time => (time.LastActive >= deadlineDay)).Count();
                 var inactiveDataCollectors = _repositoryForDataCollectors.Query.Where(time => (time.LastActive < deadlineDay)).Count();

                IDictionary<string, int> totalDataCollectors = new Dictionary<string, int>();
                totalDataCollectors.Add(new KeyValuePair<string, int>("inactive", inactiveDataCollectors));
                totalDataCollectors.Add(new KeyValuePair<string, int>("active", activeDataCollectors));

                return totalDataCollectors.AsQueryable();
            }
        }
    }
}
