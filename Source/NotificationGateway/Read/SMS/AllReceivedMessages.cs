using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.SMS
{
    public class AllReceivedMessages : IQueryFor<ReceivedMessage>
    {
        readonly IReadModelRepositoryFor<ReceivedMessage> _repositoryForReceivedMessage;

        public AllReceivedMessages(IReadModelRepositoryFor<ReceivedMessage> repositoryForReceivedMessage)
        {
            _repositoryForReceivedMessage = repositoryForReceivedMessage;
        }

        public IQueryable<ReceivedMessage> Query => _repositoryForReceivedMessage.Query.OrderByDescending(_ => _.Received);
    }
}
