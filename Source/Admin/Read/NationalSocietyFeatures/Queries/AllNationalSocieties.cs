
using System.Linq;
using Dolittle.Queries;

namespace Read.NationalSocietyFeatures.Queries
{
    public class AllNationalSocieties : IQueryFor<NationalSociety>
    {
        readonly INationalSocieties _collection;

        public AllNationalSocieties(INationalSocieties collection)
        {
            _collection = collection;
        }

        public IQueryable<NationalSociety> Query => _collection.Query.Where(_ => true);
    }
}