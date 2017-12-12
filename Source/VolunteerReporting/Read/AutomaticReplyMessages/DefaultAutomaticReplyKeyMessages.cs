using System;
using System.Collections.Generic;
using System.Text;
using Concepts;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Read.AutomaticReplyMessages
{
    public class DefaultAutomaticReplyKeyMessages : IDefaultAutomaticReplyKeyMessages
    {

        readonly IMongoDatabase _database;
        readonly IMongoCollection<DefaultAutomaticReplyKeyMessage> _collection;

        public DefaultAutomaticReplyKeyMessages(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<DefaultAutomaticReplyKeyMessage>("DefaultAutomaticReplyKeyMessage");
        }

        public async Task<IEnumerable<DefaultAutomaticReplyKeyMessage>> GetAllAsync()
        {
            var filter = Builders<DefaultAutomaticReplyKeyMessage>.Filter.Empty;
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public DefaultAutomaticReplyKeyMessage GetByTypeLanguageAndHealthRisk(AutomaticReplyKeyMessageType type, string language, Guid healthRiskId)
        {
            var filter = Builders<DefaultAutomaticReplyKeyMessage>.Filter.Where(v => v.Type == type && v.Language == language && v.HealthRiskId == healthRiskId);
            return _collection.Find(filter).FirstOrDefault();
        }

        public void Save(DefaultAutomaticReplyKeyMessage keyMessage)
        {
            var filter = Builders<DefaultAutomaticReplyKeyMessage>.Filter.Where(v => v.Type == keyMessage.Type && v.Language == keyMessage.Language && v.HealthRiskId == keyMessage.HealthRiskId);
            _collection.ReplaceOne(filter, keyMessage, new UpdateOptions { IsUpsert = true });
       }
    }
}
