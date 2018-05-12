using System;
using Concepts;
using Dolittle.ReadModels;
using Infrastructure.Read;
using MongoDB.Bson.Serialization;

namespace Read.AutomaticReplyMessages
{
    public class DefaultAutomaticReply : IReadModel
    {
        public Guid Id { get; set; }
        public AutomaticReplyType Type { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }

        public DefaultAutomaticReply(Guid id)
        {
            Id = id;
        }
    }
    public class DefaultAutomaticReplyBsonClassMap : MongoDbClassMap<DefaultAutomaticReply>
    {
        public override void Map(BsonClassMap<DefaultAutomaticReply> cm)
        {
            cm.AutoMap();
            cm.MapIdMember(r => r.Id);
        }

        public override void Register()
        {
            BsonClassMap.RegisterClassMap<DefaultAutomaticReply>(Map);
        }
    }
}