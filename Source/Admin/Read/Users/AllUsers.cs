using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Users
{
    public class AllUsers : IQueryFor<User>
    {
        readonly IReadModelRepositoryFor<User> _collection;

        public AllUsers(IReadModelRepositoryFor <User> collection)
        {
            _collection = collection;
        }

        public IQueryable<User> Query => _collection.Query;
    }
}