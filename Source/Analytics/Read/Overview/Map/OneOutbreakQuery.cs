using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;
using Concepts;

namespace Read.Overview.Map
{
    public class OneOutbreakQuery : IQueryFor<Outbreak>
    {
        readonly IReadModelRepositoryFor<Outbreak> _repositoryForOutbreak;

        public OneOutbreakQuery(IReadModelRepositoryFor<Outbreak> repositoryForOutbreak)
        {
            _repositoryForOutbreak = repositoryForOutbreak;
        }

        public IQueryable<Outbreak> Query => _repositoryForOutbreak.Query;
    }
}
