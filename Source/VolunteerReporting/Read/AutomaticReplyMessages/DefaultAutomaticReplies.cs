using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
using Infrastructure.Read.MongoDb;

namespace Read.AutomaticReplyMessages
{
    public class DefaultAutomaticReplies : ExtendedReadModelRepositoryFor<DefaultAutomaticReply>,
        IDefaultAutomaticReplies
    {
        public DefaultAutomaticReplies(IMongoDatabase database)
            : base(database, database.GetCollection<DefaultAutomaticReply>("DefaultAutomaticReply"))
        {
        }

        public IEnumerable<DefaultAutomaticReply> GetAll()
        {
            return GetMany(_ => true);
        }
        public void SaveDefaultAutomaticReply(Guid id, int type, string language, string message)
        {
            Update(new DefaultAutomaticReply(id)
            {
                Language = language,
                Message = message,
                Type = (AutomaticReplyType)type
            });
        }


        public DefaultAutomaticReply GetByTypeAndLanguage(AutomaticReplyType type, string language)
        {
            return GetOne(v => v.Type == type && v.Language == language);
        }
    }
}
