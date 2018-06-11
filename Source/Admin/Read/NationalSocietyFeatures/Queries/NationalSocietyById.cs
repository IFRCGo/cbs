using System;
using System.Linq;
using Dolittle.Queries;

namespace Read.NationalSocietyFeatures.Queries
{
    public class NationalSocietyById : IQueryFor<NationalSociety>
    {
        readonly INationalSocieties _collection;

        public Guid NationalSocietyId { get; set; }
        public NationalSocietyById(INationalSocieties collection)
        {
            _collection = collection;
        }

        public IQueryable<NationalSociety> Query => _collection.Query.Where(n => n.Id == NationalSocietyId);
    }
}