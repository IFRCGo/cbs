using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.NationalSocieties
{
    public class NationalSocietyById : IQueryFor<NationalSociety>
    {
        readonly IReadModelRepositoryFor<NationalSociety> _nationalSocieties;

        public Guid NationalSocietyId { get; set; }
        public NationalSocietyById(IReadModelRepositoryFor<NationalSociety> nationalSocieties)
        {
            _nationalSocieties = nationalSocieties;
        }

        public IQueryable<NationalSociety> Query => _nationalSocieties.Query.Where(n => n.Id == NationalSocietyId);
    }
}