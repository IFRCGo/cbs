using System.Linq;
using Dolittle.Queries;
using MongoDB.Driver.Core.WireProtocol.Messages;

namespace Read.AutomaticReplyMessages.Queries
{
    public class AllReplyMessages : IQueryFor<ReplyMessagesConfig>
    {
        readonly IReplyMessages _collection;

        public AllReplyMessages(IReplyMessages collection)
        {
            _collection = collection;
        }

        public IQueryable<ReplyMessagesConfig> Query => _collection.Query;
    }
}