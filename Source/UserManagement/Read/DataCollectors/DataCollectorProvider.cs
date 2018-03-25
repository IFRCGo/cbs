using System.Collections;
using System.Collections.Generic;
using System.Linq;
using doLittle.Read;
using MongoDB.Driver;

namespace Read.DataCollectors
{
    public class DataCollectorProvider : IQueryProviderFor<DataCollector>
    {
        public QueryProviderResult Execute(DataCollector query, PagingInfo paging)
        {
                
            var result = new QueryProviderResult();

            if (query == null)
            {
                return result;
            }

            result.Items = new List<DataCollector>{query};
            
            result.TotalItems = 1;

            return result;
        }
    }
}