
using System.Linq;
using Dolittle.Queries;

namespace Read.UserFeatures.Queries
{
    public class AllUsers : IQueryFor<User>
    {
        readonly IUsers _collection;

        public AllUsers(IUsers collection)
        {
            _collection = collection;
        }

        public IQueryable<User> Query => _collection.Query.Where(_ => true);
    }
}