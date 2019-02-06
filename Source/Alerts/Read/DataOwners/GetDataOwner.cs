using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.DataOwners
{
    public class GetDataOwner : IQueryFor<DataOwner>
    {
        readonly IReadModelRepositoryFor<DataOwner> _repositoryForDataOwner;


        public GetDataOwner(IReadModelRepositoryFor<DataOwner> repositoryForDataOwner)
        {
            _repositoryForDataOwner = repositoryForDataOwner;
        }

        public IQueryable<DataOwner> Query => _repositoryForDataOwner.Query;
    }
}
