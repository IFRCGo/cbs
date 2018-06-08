using System.Linq;
using Dolittle.Queries;

namespace Read.GreetingGenerators.Queries
{
    public class QueryableProvider : IQueryProviderFor<IQueryable<GreetingHistory>>
    {
        public QueryProviderResult Execute(IQueryable<GreetingHistory> query, PagingInfo paging)
        {
            var result = new QueryProviderResult();

            result.TotalItems = query.Count();

            if (paging.Enabled)
            {
                var start = paging.Size * paging.Number;
                var end = paging.Size;
                if (query.IsTakeEndIndex()) end += start;
                query = query.Skip(start).Take(end);
            }

            result.Items = query.AsEnumerable();

            return result;
        }
    }
}