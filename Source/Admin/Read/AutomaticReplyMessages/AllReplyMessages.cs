using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.AutomaticReplyMessages
{
    public class AllReplyMessages : IQueryFor<ReplyMessagesConfig>
    {
        readonly IReadModelRepositoryFor<ReplyMessagesConfig> _collection;

        public AllReplyMessages(IReadModelRepositoryFor<ReplyMessagesConfig> collection)
        {
            _collection = collection;
        }

        public IQueryable<ReplyMessagesConfig> Query => _collection.Query;
    }
}