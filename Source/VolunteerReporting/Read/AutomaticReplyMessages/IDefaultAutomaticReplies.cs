using System;
using Concepts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.AutomaticReplyMessages
{
    public interface IDefaultAutomaticReplies : IGenericReadModelRepositoryFor<DefaultAutomaticReply, Guid>
    {
        DefaultAutomaticReply GetByTypeAndLanguage(AutomaticReplyType type, string language);
        Task<DefaultAutomaticReply> GetByTypeAndLanguageAsync(AutomaticReplyType type, string language);

        IEnumerable<DefaultAutomaticReply> GetAll();
        Task<IEnumerable<DefaultAutomaticReply>> GetAllAsync();

        void SaveDefaultAutomaticReply(Guid id, int type, string language, string message);
        Task SaveDefaultAutomaticReplyAsync(Guid id, int type, string language, string message);
    }
}