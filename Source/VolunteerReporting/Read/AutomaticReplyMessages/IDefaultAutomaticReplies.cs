using Concepts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.AutomaticReplyMessages
{
    public interface IDefaultAutomaticReplies
    {
        DefaultAutomaticReply GetByTypeAndLanguage(AutomaticReplyType type, string language);
        Task Save(DefaultAutomaticReply automaticReply);
        Task<IEnumerable<DefaultAutomaticReply>> GetAllAsync();
    }
}