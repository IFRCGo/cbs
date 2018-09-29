using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Concepts.Project;
using Concepts.AutomaticReply;
using Infrastructure.Read.MongoDb;
using MongoDB.Driver;

namespace Read.AutomaticReplyMessages
{
    public class AutomaticReplies : ExtendedReadModelRepositoryFor<AutomaticReply>,
        IAutomaticReplies
    {
        public AutomaticReplies(IMongoDatabase database)
            : base(database)
        {
        }

        public IEnumerable<AutomaticReply> GetAll()
        {
            return GetMany(_ => true);
        }
        public IEnumerable<AutomaticReply> GetByProject(ProjectId projectId)
        {
            return GetMany(v => v.ProjectId == projectId);
        }

        public void SaveAutomaticReply(Guid id, int type, string language, string message, Guid projectId)
        {
            Update(new AutomaticReply(id)
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
    }
}
