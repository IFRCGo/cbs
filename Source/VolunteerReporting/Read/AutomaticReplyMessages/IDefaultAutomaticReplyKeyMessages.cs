using Concepts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;
using Concepts.AutomaticReply;
using Concepts.HealthRisk;

namespace Read.AutomaticReplyMessages
{
    public interface IDefaultAutomaticReplyKeyMessages : IExtendedReadModelRepositoryFor<DefaultAutomaticReplyKeyMessage>
    {
        DefaultAutomaticReplyKeyMessage GetByTypeLanguageAndHealthRisk(AutomaticReplyKeyMessageType type, string language, HealthRiskId healthRiskId);
        Task<DefaultAutomaticReplyKeyMessage> GetByTypeLanguageAndHealthRiskAsync(AutomaticReplyKeyMessageType type, string language, HealthRiskId healthRiskId);

        IEnumerable<DefaultAutomaticReplyKeyMessage> GetAll();
        Task<IEnumerable<DefaultAutomaticReplyKeyMessage>> GetAllAsync();

        void SaveDefaultAutomaticReplyKeyMessage(Guid id, int type, string language, string message, HealthRiskId healthRiskId);
        Task SaveDefaultAutomaticReplyKeyMessageAsync(Guid id, int type, string language, string message, HealthRiskId healthRiskId);
    }
}
