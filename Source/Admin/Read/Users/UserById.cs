using Dolittle.Queries;
using System;
using System.Linq;
using Dolittle.ReadModels;

namespace Read.Users
{
    public class UserById : IQueryFor<User>
    {
        readonly IReadModelRepositoryFor<User> _collection;

        public Guid UserId { get; set; }
        public UserById(IReadModelRepositoryFor<User> collection)
        {
            _collection = collection;
        }

        public IQueryable<User> Query => _collection.Query.Where(u => u.Id == UserId);
    }
}