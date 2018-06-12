using Concepts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;

namespace Read.AutomaticReplyMessages
{
    public interface IDefaultAutomaticReplyKeyMessages : IExtendedReadModelRepositoryFor<DefaultAutomaticReplyKeyMessage>
    {
        DefaultAutomaticReplyKeyMessage GetByTypeLanguageAndHealthRisk(AutomaticReplyKeyMessageType type, string language, Guid healthRiskId);

        IEnumerable<DefaultAutomaticReplyKeyMessage> GetAll();

        void SaveDefaultAutomaticReplyKeyMessage(Guid id, int type, string language, string message, Guid healthRiskId);
    }
}
