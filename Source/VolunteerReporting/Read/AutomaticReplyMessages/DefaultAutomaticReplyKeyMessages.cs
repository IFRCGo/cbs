using System;
using System.Collections.Generic;
using Concepts;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;
using MongoDB.Driver;

namespace Read.AutomaticReplyMessages
{
    public class DefaultAutomaticReplyKeyMessages : ExtendedReadModelRepositoryFor<DefaultAutomaticReplyKeyMessage>,
        IDefaultAutomaticReplyKeyMessages
    {
        public DefaultAutomaticReplyKeyMessages(IMongoDatabase database)
            : base(database, database.GetCollection<DefaultAutomaticReplyKeyMessage>("DefaultAutomaticReplyKeyMessage"))
        {}

        public IEnumerable<DefaultAutomaticReplyKeyMessage> GetAll()
        {
            return GetMany(_ => true);
        }

        public Task<IEnumerable<DefaultAutomaticReplyKeyMessage>> GetAllAsync()
        {
            return GetManyAsync(_ => true);
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

        public Task SaveDefaultAutomaticReplyKeyMessageAsync(Guid id, int type, string language, string message, HealthRiskId healthRiskId)
        {
            return UpdateAsync(new DefaultAutomaticReplyKeyMessage(id)
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

        public Task<DefaultAutomaticReplyKeyMessage> GetByTypeLanguageAndHealthRiskAsync(AutomaticReplyKeyMessageType type, string language, HealthRiskId healthRiskId)
        {
            return GetOneAsync(v => v.Type == type && v.Language == language && v.HealthRiskId == healthRiskId);
        }

    }
}
