using System;
using System.Collections.Generic;
using Concepts;
using doLittle.Read;
using MongoDB.Bson.Serialization.Attributes;


namespace Read.DataCollectors
{
    public class DataCollector : IReadModel
    { 
        [BsonId]
        public Guid DataCollectorId { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public int YearOfBirth { get; set; }
        public Sex Sex { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location Location { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public DateTimeOffset RegisteredAt { get; set; }

        public DateTimeOffset? LastReportRecievedAt { get; set; }

        public DataCollector(Guid dataCollectorId)
        {
            DataCollectorId = dataCollectorId;
        }
    }

}
