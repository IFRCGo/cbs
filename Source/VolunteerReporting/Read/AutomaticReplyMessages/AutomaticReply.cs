using System;
using Concepts;
using Dolittle.ReadModels;
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
    public static class AutomaticReplyBsonClassMapRegistrator
    {
        public static void Register()
        {
            BsonClassMap.RegisterClassMap<AutomaticReply>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(r => r.Id);
            });
        }
    }
}