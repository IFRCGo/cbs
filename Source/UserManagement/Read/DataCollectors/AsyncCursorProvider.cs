using System.Linq;
using Dolittle.Queries;
using MongoDB.Driver;

namespace Read.DataCollectors
{
    public class AsyncCursorProvider : IQueryProviderFor<IAsyncCursor<DataCollector>>
    {
        public QueryProviderResult Execute(IAsyncCursor<DataCollector> query, PagingInfo paging)
        {
                
            var result = new QueryProviderResult();

            if (!query.Any())
            {
                return result;
            }

            var list = query.ToList();
            if (paging.Enabled)
            {
                var start = paging.Size * paging.Number;
                list = list.Skip(start).Take(paging.Size).ToList();
            }

            result.Items = list;
            result.TotalItems = list.Count;

            return result;
        }
    }
}