using System;
using doLittle.Read;
using MongoDB.Bson.Serialization.Attributes;

namespace Read.GreetingGenerators
{
    public class GreetingHistory : IReadModel
    {
        [BsonId]
        public Guid DataCollectorId { get; set; }
        public string PhoneNumber { get; set; }
        //TODO: Shouldn't this contain a string Message aswell? Or should there just be a default message?
        
        public GreetingHistory(Guid dataCollectorId) {
            DataCollectorId = dataCollectorId;
        }       
    }
}
