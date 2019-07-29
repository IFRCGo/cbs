using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.DataCollectors
{
    public class AllRegions : IQueryFor<Region>
    {
        readonly IReadModelRepositoryFor<Region> _repositoryForRegion;

        public AllRegions(IReadModelRepositoryFor<Region> repositoryForRegion)
        {
            _repositoryForRegion = repositoryForRegion;
        }

        public IQueryable<Region> Query => _repositoryForRegion.Query;
    }
}
