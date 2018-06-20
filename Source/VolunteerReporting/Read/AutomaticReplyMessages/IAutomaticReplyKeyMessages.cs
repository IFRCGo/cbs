using Concepts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;
using Concepts.Project;
using Concepts.AutomaticReply;
using Concepts.HealthRisk;

namespace Read.AutomaticReplyMessages
{
    public interface IAutomaticReplyKeyMessages : IExtendedReadModelRepositoryFor<AutomaticReplyKeyMessage>
    {
        AutomaticReplyKeyMessage GetByProjectTypeLanguageAndHealthRisk(ProjectId projectId, AutomaticReplyKeyMessageType type, string language, HealthRiskId healthRiskId);
        Task<AutomaticReplyKeyMessage> GetByProjectTypeLanguageAndHealthRiskAsync(ProjectId projectId, AutomaticReplyKeyMessageType type, string language, HealthRiskId healthRiskId);

        IEnumerable<AutomaticReplyKeyMessage> GetAll();
        Task<IEnumerable<AutomaticReplyKeyMessage>> GetAllAsync();

        IEnumerable<AutomaticReplyKeyMessage> GetByProject(ProjectId projectId);
        Task<IEnumerable<AutomaticReplyKeyMessage>> GetByProjectAsync(ProjectId projectId);

        void SaveAutomaticReplyKeyMessage(Guid id, int type, string language, string message, ProjectId projectId, HealthRiskId healthRiskId);
        Task SaveAutomaticReplyKeyMessageAsync(Guid id, int type, string language, string message, ProjectId projectId, HealthRiskId healthRiskId);
    }
}
