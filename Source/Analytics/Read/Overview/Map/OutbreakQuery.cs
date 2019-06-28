using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Overview.Map
{
    public class OutbreakQuery : IQueryFor<Outbreak>
    {
        readonly IReadModelRepositoryFor<Outbreak> _repositoryForOutbreak;

        public OutbreakQuery(IReadModelRepositoryFor<Outbreak> repositoryForOutbreak)
        {
            _repositoryForOutbreak = repositoryForOutbreak;
        }

        public IQueryable<Outbreak> Query => _repositoryForOutbreak.Query;
    }
}
