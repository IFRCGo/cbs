using System;
using System.Collections.Generic;
using Concepts;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;
using MongoDB.Driver;
using Concepts.HealthRisk;
using Concepts.AutomaticReply;

namespace Read.AutomaticReplyMessages
{
    public class DefaultAutomaticReplyKeyMessages : ExtendedReadModelRepositoryFor<DefaultAutomaticReplyKeyMessage>,
        IDefaultAutomaticReplyKeyMessages
    {
        public DefaultAutomaticReplyKeyMessages(IMongoDatabase database)
            : base(database)
        {}

        public IEnumerable<DefaultAutomaticReplyKeyMessage> GetAll()
        {
            return GetMany(_ => true);
        }

        public void SaveDefaultAutomaticReplyKeyMessage(Guid id, int type, string language, string message, HealthRiskId healthRiskId)
        {
            Update(new DefaultAutomaticReplyKeyMessage(id)
            {
                HealthRiskId = healthRiskId,
                Language = language,
                Message = message,
                Type = (AutomaticReplyKeyMessageType)type
            });
        }

        public DefaultAutomaticReplyKeyMessage GetByTypeLanguageAndHealthRisk(AutomaticReplyKeyMessageType type, string language, HealthRiskId healthRiskId)
        {
            return GetOne(v => v.Type == type && v.Language == language && v.HealthRiskId == healthRiskId);
        }
    }
}
