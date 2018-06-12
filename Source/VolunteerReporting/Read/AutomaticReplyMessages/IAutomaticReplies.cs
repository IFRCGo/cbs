using Concepts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;

namespace Read.AutomaticReplyMessages
{
    public interface IAutomaticReplies : IExtendedReadModelRepositoryFor<AutomaticReply>
    {
        AutomaticReply GetByProjectTypeAndLanguage(ProjectId projectId, AutomaticReplyType type, string language);
        Task<AutomaticReply> GetByProjectTypeAndLanguageAsync(ProjectId projectId, AutomaticReplyType type, string language);

        IEnumerable<AutomaticReply> GetAll();
        Task<IEnumerable<AutomaticReply>> GetAllAsync();

        IEnumerable<AutomaticReply> GetByProject(ProjectId projectId);
        Task<IEnumerable<AutomaticReply>> GetByProjectAsync(ProjectId projectId);

        void SaveAutomaticReply(Guid id, int type, string language, string message, ProjectId projectId);
        Task SaveAutomaticReplyAsync(Guid id, int type, string language, string message, ProjectId projectId);
    }
}
