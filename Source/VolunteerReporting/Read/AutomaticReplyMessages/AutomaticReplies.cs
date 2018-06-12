using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts;
using Infrastructure.Read.MongoDb;
using MongoDB.Driver;

namespace Read.AutomaticReplyMessages
{
    public class AutomaticReplies : ExtendedReadModelRepositoryFor<AutomaticReply>,
        IAutomaticReplies
    {
        public AutomaticReplies(IMongoDatabase database)
            : base(database, database.GetCollection<AutomaticReply>("AutomaticReply"))
        {
        }

        public IEnumerable<AutomaticReply> GetAll()
        {
            return GetMany(_ => true);
        }

        public Task<IEnumerable<AutomaticReply>> GetAllAsync()
        {
            return GetManyAsync(_ => true);
        }

        public IEnumerable<AutomaticReply> GetByProject(ProjectId projectId)
        {
            return GetMany(v => v.ProjectId == projectId);
        }

        public Task<IEnumerable<AutomaticReply>> GetByProjectAsync(ProjectId projectId)
        {
            return GetManyAsync(v => v.ProjectId == projectId);
        }

        public void SaveAutomaticReply(Guid id, int type, string language, string message, ProjectId projectId)
        {
            Update(new AutomaticReply(id)
            {
                Language = language,
                Message = message,
                ProjectId = projectId,
                Type = (AutomaticReplyType)type
            });
        }

        public Task SaveAutomaticReplyAsync(Guid id, int type, string language, string message, ProjectId projectId)
        {
            return UpdateAsync(new AutomaticReply(id)
            {
                Language = language,
                Message = message,
                ProjectId = projectId,
                Type = (AutomaticReplyType)type
            });
        }

        public AutomaticReply GetByProjectTypeAndLanguage(ProjectId projectId, AutomaticReplyType type, string language)
        {
            return GetOne(
                v =>
                    v.ProjectId == projectId
                    && v.Type == type
                    && v.Language == language
            );
        }

        public Task<AutomaticReply> GetByProjectTypeAndLanguageAsync(ProjectId projectId, AutomaticReplyType type, string language)
        {
            return GetOneAsync(
                v =>
                    v.ProjectId == projectId
                    && v.Type == type
                    && v.Language == language
            );
        }
    }
}
