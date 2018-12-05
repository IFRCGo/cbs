using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Projects
{
    public class ProjectById : IQueryFor<Project>
    {
        private readonly IReadModelRepositoryFor<Project> _collection;

        public Guid ProjectId { get; set; }

        public ProjectById(IReadModelRepositoryFor<Project> collection)
        {
            _collection = collection;
        }

        public IQueryable<Project> Query => _collection.Query.Where(p => p.Id == ProjectId);
    }
}