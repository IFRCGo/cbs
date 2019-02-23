using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.SMS.Gateways
{
    public class SmsGatewayGetEnabledQuery : IQueryFor<SmsGateway>
    {
        readonly IReadModelRepositoryFor<SmsGateway> _repositoryForSmsGateway;

        public SmsGatewayGetEnabledQuery(IReadModelRepositoryFor<SmsGateway> repositoryForSmsGateway)
        {
            _repositoryForSmsGateway = repositoryForSmsGateway;
        }

        public IQueryable<SmsGateway> Query =>
            _repositoryForSmsGateway.Query.Where(_ => _.Enabled);
    }
}
