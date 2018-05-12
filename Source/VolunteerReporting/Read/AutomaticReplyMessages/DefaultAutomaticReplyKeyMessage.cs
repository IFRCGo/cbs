using Concepts;
using System;
using Dolittle.ReadModels;
using Infrastructure.Read;
using MongoDB.Bson.Serialization;

namespace Read.AutomaticReplyMessages
{
    public class DefaultAutomaticReplyKeyMessage : IReadModel
    {
        public Guid Id { get; set; }
        public Guid HealthRiskId { get; set; }
        public AutomaticReplyKeyMessageType Type { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }

        public DefaultAutomaticReplyKeyMessage(Guid id)
        {
            Id = id;
        }
    }
    public class DefaultAutomaticReplyKeyMessageBsonClassMap : MongoDbClassMap<DefaultAutomaticReplyKeyMessage>
    {
        public override void Map(BsonClassMap<DefaultAutomaticReplyKeyMessage> cm)
        {
            cm.AutoMap();
            cm.MapIdMember(r => r.Id);
        }

        public override void Register()
        {
            BsonClassMap.RegisterClassMap<DefaultAutomaticReplyKeyMessage>(Map);
        }
    }
}