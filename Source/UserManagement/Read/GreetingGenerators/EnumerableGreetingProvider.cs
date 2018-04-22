using System.Collections.Generic;
using System.Linq;
using doLittle.Read;

namespace Read.GreetingGenerators
{
    public class EnumerableGreetingProvider : IQueryProviderFor<IEnumerable<GreetingHistory>>
    {
        public QueryProviderResult Execute(IEnumerable<GreetingHistory> query, PagingInfo paging)
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