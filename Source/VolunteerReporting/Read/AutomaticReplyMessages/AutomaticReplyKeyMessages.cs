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

        public Task<IEnumerable<AutomaticReplyKeyMessage>> GetAllAsync()
        {
            return GetManyAsync(_ => true);
        }

        public IEnumerable<AutomaticReplyKeyMessage> GetByProject(ProjectId projectId)
        {
            return GetMany(_ => _.ProjectId == projectId);
        }

        public Task<IEnumerable<AutomaticReplyKeyMessage>> GetByProjectAsync(ProjectId projectId)
        {
            return GetManyAsync(_ => _.ProjectId == projectId);
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

        public Task SaveAutomaticReplyKeyMessageAsync(Guid id, int type, string language, string message, ProjectId projectId,
            HealthRiskId healthRiskId)
        {
            return UpdateAsync(new AutomaticReplyKeyMessage(id)
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

        public Task<AutomaticReplyKeyMessage> GetByProjectTypeLanguageAndHealthRiskAsync(ProjectId projectId, AutomaticReplyKeyMessageType type, 
            string language, HealthRiskId healthRiskId)
        {
            return GetOneAsync(
                v => v.ProjectId == projectId
                     && v.Type == type
                     && v.Language == language
                     && v.HealthRiskId == healthRiskId);
        }
    }
}
