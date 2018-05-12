using System;
using Concepts;
using Dolittle.ReadModels;
using Infrastructure.Read;
using MongoDB.Bson.Serialization;

namespace Read.AutomaticReplyMessages
{
    public class AutomaticReply : IReadModel
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public AutomaticReplyType Type { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }

        public AutomaticReply(Guid id)
        {
            Id = id;
        }
    }
    public class AutomaticReplyBsonClassMap : MongoDbClassMap<AutomaticReply>
    {
        public override void Map(BsonClassMap<AutomaticReply> cm)
        {
            cm.AutoMap();
            cm.MapIdMember(r => r.Id);
        }
    }
}