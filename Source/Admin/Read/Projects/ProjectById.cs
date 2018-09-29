using System;
using System.Linq;
using Dolittle.Queries;

namespace Read.Projects
{
    public class ProjectById : IQueryFor<Project>
    {
        private readonly IProjects _collection;

        public Guid ProjectId { get; set; }

        public ProjectById(IProjects collection)
        {
            _collection = collection;
        }

        public IQueryable<Project> Query => _collection.Query.Where(p => p.Id == ProjectId);
    }
}