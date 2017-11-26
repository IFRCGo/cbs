using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Concepts;
using MongoDB.Driver;

namespace Read.AutomaticReplyMessages
{
    public class AutomaticReplies : IAutomaticReplies
    {
        readonly IMongoDatabase _database;
        readonly IMongoCollection<AutomaticReply> _collection;

        public AutomaticReplies(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<AutomaticReply>("AutomaticReply");
        }

        public async Task<IEnumerable<AutomaticReply>> GetAllAsync()
        {
            var filter = Builders<AutomaticReply>.Filter.Empty;
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public async Task<IEnumerable<AutomaticReply>> GetByProjectAsync(Guid projectId)
        {
            /////////////////////
            // This is a hack that shouldn't be here. It should either be placed in a separate utility class
            // or, we might want to make a global change for the way MongoDB handles Guids?
            // (without this conversion, the Find call will return no records)
            // ref: https://stackoverflow.com/questions/45738423/get-a-document-by-luuid
            // -----
            // Update on 2017-11-17: This works now without this hack. I am leaving this here, just in case this
            // turns out to be a problem again, but it can be removed if it is not seen in the near future
            /////////////////////
            //var luuid = projectId;
            //var bytes = MongoDB.Bson.GuidConverter.ToBytes(luuid, MongoDB.Bson.GuidRepresentation.PythonLegacy);
            //var csuuid = new Guid(bytes);

            var filter = Builders<AutomaticReply>.Filter.Eq(c => c.ProjectId, projectId);
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public async Task<AutomaticReply> GetByProjectTypeAndLanguageAsync(Guid projectId, AutomaticReplyType type, string language)
        {
            var filter = Builders<AutomaticReply>.Filter.Where(v => 
                v.ProjectId == projectId &&
                v.Type == type && 
                v.Language == language
            );
            var automaticReply = await _collection.FindAsync(filter);
            return automaticReply.FirstOrDefault();
        }

        public void Save(AutomaticReply automaticReply)
        {
            var filter = Builders<AutomaticReply>.Filter.Where(v => v.Type == automaticReply.Type && v.Language == automaticReply.Language);
            _collection.ReplaceOne(filter, automaticReply, new UpdateOptions { IsUpsert = true });
        }
    }
}
