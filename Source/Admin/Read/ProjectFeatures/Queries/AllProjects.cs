using System.Linq;
using Dolittle.Queries;

namespace Read.ProjectFeatures.Queries
{
    public class AllProjects : IQueryFor<Project>
    {
        private readonly IProjects _collection;

        public AllProjects(IProjects collection)
        {
            _collection = collection;
        }

        public IQueryable<Project> Query => _collection.Query.Where(_ => true);
    }
}