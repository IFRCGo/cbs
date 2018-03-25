using System.Linq;
using doLittle.Read;
using MongoDB.Driver;
using Read.StaffUsers.Models;

namespace Read.StaffUsers
{
    public class StaffUserAsyncCursorProvider<T> : IQueryProviderFor<StaffUserIAsyncCursor<T>>
        where T : BaseUser
    {
        //TODO: May have to make seperate providers for each ReadModel
        public QueryProviderResult Execute(StaffUserIAsyncCursor<T> query, PagingInfo paging)
        {
            var result = new QueryProviderResult();

            if (!query.Cursor.Any())
            {
                return result;
            }

            var list = query.Cursor.ToList();

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