using System;
using Concepts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;
using Concepts.AutomaticReply;

namespace Read.AutomaticReplyMessages
{
    public interface IDefaultAutomaticReplies : IExtendedReadModelRepositoryFor<DefaultAutomaticReply>
    {
        DefaultAutomaticReply GetByTypeAndLanguage(AutomaticReplyType type, string language);
        IEnumerable<DefaultAutomaticReply> GetAll();
        void SaveDefaultAutomaticReply(Guid id, int type, string language, string message);
    }
}