using System;
using Dolittle.ReadModels;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Read.GreetingGenerators
{
    public class GreetingHistory : IReadModel
    {
        public Guid DataCollectorId { get; set; }
        public string PhoneNumber { get; set; }
        //TODO: Shouldn't this contain a string Message aswell? Or should there just be a default message?
        
        public GreetingHistory(Guid dataCollectorId) {
            DataCollectorId = dataCollectorId;
        }       
    }

    public static class GreetingHistoryBsonClassMapRegistrator
    {
        public static void Register()
        {
            BsonClassMap.RegisterClassMap<GreetingHistory>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(g => g.DataCollectorId);
            });
        }
    }
}
