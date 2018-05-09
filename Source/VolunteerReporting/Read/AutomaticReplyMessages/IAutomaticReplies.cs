using Concepts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Read;

namespace Read.AutomaticReplyMessages
{
    public interface IAutomaticReplies : IExtendedReadModelRepositoryFor<AutomaticReply>
    {
        AutomaticReply GetByProjectTypeAndLanguage(Guid projectId, AutomaticReplyType type, string language);
        Task<AutomaticReply> GetByProjectTypeAndLanguageAsync(Guid projectId, AutomaticReplyType type, string language);

        IEnumerable<AutomaticReply> GetAll();
        Task<IEnumerable<AutomaticReply>> GetAllAsync();

        IEnumerable<AutomaticReply> GetByProject(Guid projectId);
        Task<IEnumerable<AutomaticReply>> GetByProjectAsync(Guid projectId);

        void SaveAutomaticReply(Guid id, int type, string language, string message, Guid projectId);
        Task SaveAutomaticReplyAsync(Guid id, int type, string language, string message, Guid projectId);
    }
}
