using Concepts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.AutomaticReplyMessages
{
    public interface IDefaultAutomaticReplyKeyMessages : IGenericReadModelRepositoryFor<DefaultAutomaticReplyKeyMessage, Guid>
    {
        DefaultAutomaticReplyKeyMessage GetByTypeLanguageAndHealthRisk(AutomaticReplyKeyMessageType type, string language, Guid healthRiskId);
        Task<DefaultAutomaticReplyKeyMessage> GetByTypeLanguageAndHealthRiskAsync(AutomaticReplyKeyMessageType type, string language, Guid healthRiskId);

        IEnumerable<DefaultAutomaticReplyKeyMessage> GetAll();
        Task<IEnumerable<DefaultAutomaticReplyKeyMessage>> GetAllAsync();

        void SaveDefaultAutomaticReplyKeyMessage(Guid id, int type, string language, string message, Guid healthRiskId);
        Task SaveDefaultAutomaticReplyKeyMessageAsync(Guid id, int type, string language, string message, Guid healthRiskId);
    }
}
