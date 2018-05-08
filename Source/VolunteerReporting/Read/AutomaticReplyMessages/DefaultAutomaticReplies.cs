using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;

namespace Read.AutomaticReplyMessages
{
    public class DefaultAutomaticReplies : GenericReadModelRepositoryFor<DefaultAutomaticReply, Guid>,
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

        public Task<IEnumerable<DefaultAutomaticReply>> GetAllAsync()
        {
            return GetManyAsync(_ => true);
        }

        public void SaveDefaultAutomaticReply(Guid id, int type, string language, string message)
        {
            Save(new DefaultAutomaticReply(id)
            {
                Language = language,
                Message = message,
                Type = (AutomaticReplyType)type
            });
        }

        public Task SaveDefaultAutomaticReplyAsync(Guid id, int type, string language, string message)
        {
            return SaveAsync(new DefaultAutomaticReply(id)
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

        public Task<DefaultAutomaticReply> GetByTypeAndLanguageAsync(AutomaticReplyType type, string language)
        {
            return GetOneAsync(v => v.Type == type && v.Language == language);
        }

    }
}
