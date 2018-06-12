using Concepts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;

namespace Read.AutomaticReplyMessages
{
    public class AutomaticReplyKeyMessages : ExtendedReadModelRepositoryFor<AutomaticReplyKeyMessage>,
        IAutomaticReplyKeyMessages
    {

        public AutomaticReplyKeyMessages(IMongoDatabase database)
            : base(database, database.GetCollection<AutomaticReplyKeyMessage>("AutomaticReplyKeyMessage"))
        {
        }

        public IEnumerable<AutomaticReplyKeyMessage> GetAll()
        {
            return GetMany(_ => true);
        }

        public IEnumerable<AutomaticReplyKeyMessage> GetByProject(Guid projectId)
        {
            return GetMany(_ => _.ProjectId == projectId);
        }
        public void SaveAutomaticReplyKeyMessage(Guid id, int type, string language, string message, Guid projectId,
            Guid healthRiskId)
        {
            Update(new AutomaticReplyKeyMessage(id)
            {
                HealthRiskId = healthRiskId,
                Message = message,
                Language = language,
                ProjectId = projectId,
                Type = (AutomaticReplyKeyMessageType)type
            });
        }
        public AutomaticReplyKeyMessage GetByProjectTypeLanguageAndHealthRisk(Guid projectId, AutomaticReplyKeyMessageType type,
            string language, Guid healthRiskId)
        {
            return GetOne(
                v => v.ProjectId == projectId
                     && v.Type == type
                     && v.Language == language
                     && v.HealthRiskId == healthRiskId);
        }
    }
}
