using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.NationalSocieties
{
    public class AllNationalSocieties : IQueryFor<NationalSociety>
    {
        readonly IReadModelRepositoryFor<NationalSociety> _collection;

        public AllNationalSocieties(IReadModelRepositoryFor<NationalSociety> collection)
        {
            _collection = collection;
        }

        public IQueryable<NationalSociety> Query => _collection.Query;
    }
}