using System;
using System.Collections.Generic;
using Concepts;
using Dolittle.ReadModels;
using Infrastructure.Read;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;


namespace Read.DataCollectors
{
    public class DataCollector : IReadModel
    { 
        public Guid DataCollectorId { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public int YearOfBirth { get; set; }
        public Sex Sex { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location Location { get; set; }

        public string District { get; set; }
        public string Region { get; set; }
        public string Village { get; set; }

        public List<PhoneNumber> PhoneNumbers { get; set; }
        public DateTimeOffset RegisteredAt { get; set; }

        public DateTimeOffset? LastReportRecievedAt { get; set; }

        public DataCollector(Guid dataCollectorId)
        {
            DataCollectorId = dataCollectorId;
        }
    }

    public class DataCollectorClassMap : IMongoDbClassMapFor<DataCollector>
    {
        public void Map(BsonClassMap<DataCollector> cm)
        {
            cm.AutoMap();

            cm.MapIdMember(d => d.DataCollectorId);
        }

        public void Register()
        {
            BsonClassMap.RegisterClassMap<DataCollector>(Map);
        }

        public bool IsRegistered()
        {
           return BsonClassMap.IsClassMapRegistered(typeof(DataCollector));
        }
    }
}
