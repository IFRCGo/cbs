using Concepts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.AutomaticReplyMessages
{
    public interface IAutomaticReplies
    {
        Task<AutomaticReply> GetByProjectTypeAndLanguageAsync(Guid projectId, AutomaticReplyType type, string language);
        void Save(AutomaticReply automaticReply);
        void Delete(AutomaticReply automaticReply);
        Task<IEnumerable<AutomaticReply>> GetAllAsync();
        Task<IEnumerable<AutomaticReply>> GetByProjectAsync(Guid projectId);
    }
}
