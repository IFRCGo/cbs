using Concepts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.AutomaticReplyMessages
{
    public interface IAutomaticReplyKeyMessages
    {
        Task<AutomaticReplyKeyMessage> GetByProjectTypeLanguageAndHealthRiskAsync(Guid projectId, AutomaticReplyKeyMessageType type, string language, Guid healthRiskId);
        Task Save(AutomaticReplyKeyMessage keyMessage);
        Task Remove(Guid keyMessageId);
        Task<IEnumerable<AutomaticReplyKeyMessage>> GetAllAsync();
        Task<IEnumerable<AutomaticReplyKeyMessage>> GetByProjectAsync(Guid projectId);
    }
}
