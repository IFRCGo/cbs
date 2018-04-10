
using System.Collections.Generic;
using doLittle.Read;

namespace Read.DataCollectors
{
    public class DataCollectorProvider : IQueryProviderFor<DataCollector>
    {
        public QueryProviderResult Execute(DataCollector query, PagingInfo paging)
        {
                
            var result = new QueryProviderResult();

            if (query == null)
            {
                //TODO: Perhaps throw apropriate exception
                return result;
            }

            result.Items = new List<DataCollector>{query};
            
            result.TotalItems = 1;

            return result;
        }
    }
}