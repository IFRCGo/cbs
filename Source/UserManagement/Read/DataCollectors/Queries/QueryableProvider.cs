using System.Linq;
using Dolittle.Queries;

namespace Read.DataCollectors.Queries
{
    public class QueryableProvider : IQueryProviderFor<IQueryable<DataCollector>>
    {
        public QueryProviderResult Execute(IQueryable<DataCollector> query, PagingInfo paging)
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