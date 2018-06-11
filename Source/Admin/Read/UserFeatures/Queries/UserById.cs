using Dolittle.Queries;
using System;
using System.Linq;

namespace Read.UserFeatures.Queries
{
    public class UserById : IQueryFor<User>
    {
        readonly IUsers _collection;

        public Guid UserId { get; set; }
        public UserById(IUsers collection)
        {
            _collection = collection;
        }

        public IQueryable<User> Query => _collection.Query.Where(u => u.Id == UserId);
    }
}