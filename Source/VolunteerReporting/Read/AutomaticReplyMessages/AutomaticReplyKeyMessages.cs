using Concepts.AutomaticReply;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Read.MongoDb;
using Concepts.Project;
using Concepts.HealthRisk;

namespace Read.AutomaticReplyMessages
{
    public class AutomaticReplyKeyMessages : ExtendedReadModelRepositoryFor<AutomaticReplyKeyMessage>,
        IAutomaticReplyKeyMessages
    {

        public AutomaticReplyKeyMessages(IMongoDatabase database)
            : base(database)
        {
        }

        public IEnumerable<AutomaticReplyKeyMessage> GetAll()
        {
            return GetMany(_ => true);
        }

        public IEnumerable<AutomaticReplyKeyMessage> GetByProject(ProjectId projectId)
        {
            return GetMany(_ => _.ProjectId == projectId);
        }
        public void SaveAutomaticReplyKeyMessage(Guid id, int type, string language, string message, ProjectId projectId,
            HealthRiskId healthRiskId)
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
        public AutomaticReplyKeyMessage GetByProjectTypeLanguageAndHealthRisk(ProjectId projectId, AutomaticReplyKeyMessageType type,
            string language, HealthRiskId healthRiskId)
        {
            return GetOne(
                v => v.ProjectId == projectId
                     && v.Type == type
                     && v.Language == language
                     && v.HealthRiskId == healthRiskId);
        }
    }
}
