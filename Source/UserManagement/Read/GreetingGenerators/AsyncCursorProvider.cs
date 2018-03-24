using System.Linq;
using doLittle.Read;
using MongoDB.Driver;

namespace Read.GreetingGenerators
{
    public class AsyncCursorProvider : IQueryProviderFor<IAsyncCursor<GreetingHistory>>
    {
        public QueryProviderResult Execute(IAsyncCursor<GreetingHistory> query, PagingInfo paging)
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