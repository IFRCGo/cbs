using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Projects
{
    public class AllProjects : IQueryFor<Project>
    {
        private readonly IReadModelRepositoryFor<Project> _collection;

        public AllProjects(IReadModelRepositoryFor<Project> collection)
        {
            _collection = collection;
        }

        public IQueryable<Project> Query => _collection.Query;
    }
}