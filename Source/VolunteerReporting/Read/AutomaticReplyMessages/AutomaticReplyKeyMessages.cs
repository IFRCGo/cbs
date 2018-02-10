using Concepts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Read.AutomaticReplyMessages
{
    public class AutomaticReplyKeyMessages : IAutomaticReplyKeyMessages
    {
        readonly IMongoDatabase _database;
        readonly IMongoCollection<AutomaticReplyKeyMessage> _collection;

        public AutomaticReplyKeyMessages(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<AutomaticReplyKeyMessage>("AutomaticReplyKeyMessage");
        }

        public async Task<IEnumerable<AutomaticReplyKeyMessage>> GetAllAsync()
        {
            var filter = Builders<AutomaticReplyKeyMessage>.Filter.Empty;
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public async Task<IEnumerable<AutomaticReplyKeyMessage>> GetByProjectAsync(Guid projectId)
        {
            var filter = Builders<AutomaticReplyKeyMessage>.Filter.Eq(c => c.ProjectId, projectId);
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public async Task<AutomaticReplyKeyMessage> GetByProjectTypeLanguageAndHealthRiskAsync(Guid projectId, AutomaticReplyKeyMessageType type, string language, Guid healthRiskId)
        {
            var filter = Builders<AutomaticReplyKeyMessage>.Filter.Where(v =>
                v.ProjectId == projectId &&
                v.Type == type &&
                v.Language == language && 
                v.HealthRiskId == healthRiskId
            );
            var automaticReply = await _collection.FindAsync(filter);
            return automaticReply.FirstOrDefault();
        }

        public void Save(AutomaticReplyKeyMessage keyMessage)
        {
            var filter = Builders<AutomaticReplyKeyMessage>.Filter.Where(v => v.Type == keyMessage.Type && v.Language == keyMessage.Language && v.HealthRiskId == keyMessage.HealthRiskId);
            _collection.ReplaceOne(filter, keyMessage, new UpdateOptions { IsUpsert = true });
        }

        public void Delete(AutomaticReplyKeyMessage keyMessage)
        {
            var filter = Builders<AutomaticReplyKeyMessage>.Filter.Eq(v => v.Id, keyMessage.Id);
            _collection.DeleteOne(filter);
        }
    }
}
