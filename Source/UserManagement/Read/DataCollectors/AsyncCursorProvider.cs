using System.Linq;
using doLittle.Read;
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
            result.TotalItems = list.Count;

            if (paging.Enabled)
            {
                result.TotalItems = paging.Size;

                var start = paging.Size * paging.Number;
                list = list.Skip(start).Take(paging.Size).ToList();
            }

            result.Items = list;

            return result;
        }
    }
}