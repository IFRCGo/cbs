using System.Linq;
using Dolittle.Queries;
using Read.StaffUsers.Models;

namespace Read.StaffUsers.Queries
{
    public class QueryableProvider<T> : IQueryProviderFor<IQueryable<T>>
        where T : BaseUser
    {
        public QueryProviderResult Execute(IQueryable<T> query, PagingInfo paging)
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