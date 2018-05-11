using System.Collections.Generic;
using System.Linq;
using Dolittle.Queries;

namespace Read.DataCollectors.Queries
{
    public class EnumerableDataCollectorProvider : IQueryProviderFor<IEnumerable<DataCollector>>
    {
        public QueryProviderResult Execute(IEnumerable<DataCollector> query, PagingInfo paging)
        {
            var result = new QueryProviderResult();

            var dataCollectors = query.ToList();
            if (!dataCollectors.Any())
            {
                return result;
            }
            
            if (paging.Enabled)
            {
                var start = paging.Size * paging.Number;
                dataCollectors = dataCollectors.Skip(start).Take(paging.Size).ToList();
            }

            result.Items = dataCollectors;
            result.TotalItems = dataCollectors.Count;

            return result;
        }
    }
}