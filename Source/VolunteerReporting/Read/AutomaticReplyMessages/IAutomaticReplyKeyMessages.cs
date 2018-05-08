using Concepts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.AutomaticReplyMessages
{
    public interface IAutomaticReplyKeyMessages : IGenericReadModelRepositoryFor<AutomaticReplyKeyMessage, Guid>
    {
        AutomaticReplyKeyMessage GetByProjectTypeLanguageAndHealthRisk(Guid projectId, AutomaticReplyKeyMessageType type, string language, Guid healthRiskId);
        Task<AutomaticReplyKeyMessage> GetByProjectTypeLanguageAndHealthRiskAsync(Guid projectId, AutomaticReplyKeyMessageType type, string language, Guid healthRiskId);

        IEnumerable<AutomaticReplyKeyMessage> GetAll();
        Task<IEnumerable<AutomaticReplyKeyMessage>> GetAllAsync();

        IEnumerable<AutomaticReplyKeyMessage> GetByProject(Guid projectId);
        Task<IEnumerable<AutomaticReplyKeyMessage>> GetByProjectAsync(Guid projectId);

        void SaveAutomaticReplyKeyMessage(Guid id, int type, string language, string message, Guid projectId, Guid healthRiskId);
        Task SaveAutomaticReplyKeyMessageAsync(Guid id, int type, string language, string message, Guid projectId, Guid healthRiskId);
    }
}
