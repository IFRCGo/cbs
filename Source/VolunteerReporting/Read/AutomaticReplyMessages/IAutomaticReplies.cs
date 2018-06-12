using Concepts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;

namespace Read.AutomaticReplyMessages
{
    public interface IAutomaticReplies : IExtendedReadModelRepositoryFor<AutomaticReply>
    {
        AutomaticReply GetByProjectTypeAndLanguage(Guid projectId, AutomaticReplyType type, string language);

        IEnumerable<AutomaticReply> GetAll();

        IEnumerable<AutomaticReply> GetByProject(Guid projectId);

        void SaveAutomaticReply(Guid id, int type, string language, string message, Guid projectId);
    }
}
