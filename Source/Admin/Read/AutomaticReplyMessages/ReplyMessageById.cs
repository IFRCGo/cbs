using System;
using System.Linq;
using Dolittle.Queries;

namespace Read.AutomaticReplyMessages
{
    public class ReplyMessageById : IQueryFor<ReplyMessagesConfig>
    {
        readonly IReplyMessages _collection;

        public Guid ReplyMessageId { get; set; }
        public ReplyMessageById(IReplyMessages collection)
        {
            _collection = collection;
        }

        public IQueryable<ReplyMessagesConfig> Query => _collection.Query.Where(m => m.Id == ReplyMessageId);
    }
    
}