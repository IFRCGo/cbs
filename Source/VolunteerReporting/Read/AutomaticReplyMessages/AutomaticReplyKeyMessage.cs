
using System;
using Concepts;
using Dolittle.ReadModels;
using Infrastructure.Read;
using MongoDB.Bson.Serialization;

namespace Read.AutomaticReplyMessages
{
    public class AutomaticReplyKeyMessage : IReadModel
    {
        public Guid Id { get; set; }
        public Guid HealthRiskId { get; set; }
        public Guid ProjectId { get; set; }
        public AutomaticReplyKeyMessageType Type { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }

        public AutomaticReplyKeyMessage(Guid id)
        {
            Id = id;
        } 
    }

    public class AutomaticReplyKeyMessageBsonClassMap : MongoDbClassMap<AutomaticReplyKeyMessage>
    {
        public override void Map(BsonClassMap<AutomaticReplyKeyMessage> cm)
        {
            cm.AutoMap();
            cm.MapIdMember(r => r.Id);
        }
    }
}