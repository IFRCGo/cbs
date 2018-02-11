using Concepts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.AutomaticReplyMessages
{
    public interface IDefaultAutomaticReplyKeyMessages
    {
        DefaultAutomaticReplyKeyMessage GetByTypeLanguageAndHealthRisk(AutomaticReplyKeyMessageType type, string language, Guid healthRiskId);
        Task Save(DefaultAutomaticReplyKeyMessage keyMessage);
        Task<IEnumerable<DefaultAutomaticReplyKeyMessage>> GetAllAsync();
    }
}
