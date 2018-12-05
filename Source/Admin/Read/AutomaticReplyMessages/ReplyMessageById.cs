using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.AutomaticReplyMessages
{
    public class ReplyMessageById : IQueryFor<ReplyMessagesConfig>
    {
        readonly IReadModelRepositoryFor<ReplyMessagesConfig> _collection;

        public Guid ReplyMessageId { get; set; }
        public ReplyMessageById(IReadModelRepositoryFor<ReplyMessagesConfig> collection)
        {
            _collection = collection;
        }

        public IQueryable<ReplyMessagesConfig> Query => _collection.Query.Where(m => m.Id == ReplyMessageId);
    }    
}