using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Infrastructure.Read
{
    public class QueryableProvider<T> : IQueryProviderFor<IQueryable<T>>
        where T : IReadModel
    {
        public QueryProviderResult Execute(IQueryable<T> query, PagingInfo paging)
        {
            var result = new QueryProviderResult
            {
                TotalItems = query.Count()
            };

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