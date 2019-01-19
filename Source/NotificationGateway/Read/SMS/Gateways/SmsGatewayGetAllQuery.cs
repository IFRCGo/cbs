using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.SMS.Gateways
{
    public class SmsGatewayGetAllQuery : IQueryFor<SmsGateway>
    {
        readonly IReadModelRepositoryFor<SmsGateway> _collection;

        public SmsGatewayGetAllQuery(IReadModelRepositoryFor<SmsGateway> repositoryForSmsGateway)
        {
            _collection = repositoryForSmsGateway;
        }

        public IQueryable<SmsGateway> Query => _collection.Query;
    }
}
