using Concepts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;

namespace Read.AutomaticReplyMessages
{
    public interface IAutomaticReplyKeyMessages : IExtendedReadModelRepositoryFor<AutomaticReplyKeyMessage>
    {
        AutomaticReplyKeyMessage GetByProjectTypeLanguageAndHealthRisk(Guid projectId, AutomaticReplyKeyMessageType type, string language, Guid healthRiskId);
        IEnumerable<AutomaticReplyKeyMessage> GetAll();

        IEnumerable<AutomaticReplyKeyMessage> GetByProject(Guid projectId);

        void SaveAutomaticReplyKeyMessage(Guid id, int type, string language, string message, Guid projectId, Guid healthRiskId);
    }
}
