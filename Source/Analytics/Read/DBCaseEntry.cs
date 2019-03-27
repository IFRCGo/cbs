using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Read
{
    public class DbCaseEntry
    {
        public DbCaseEntry(Guid dataCollectorId, int numberOfMalesAged5AndOlder, int numberOfFemalesUnder5, int numberOfFemalesAged5AndOlder, int numberOfMalesUnder5, DateTimeOffset timestamp, int healthRisk, string origin, double longitude, double latitude)
        {
            DataCollectorId = dataCollectorId;
            NumberOfMalesAged5AndOlder = numberOfMalesAged5AndOlder;
            NumberOfFemalesUnder5 = numberOfFemalesUnder5;
            NumberOfFemalesAged5AndOlder = numberOfFemalesAged5AndOlder;
            NumberOfMalesUnder5 = numberOfMalesUnder5;
            Timestamp = timestamp;
            HealthRisk = healthRisk;
            Origin = origin;
            Longitude = longitude;
            Latitude = latitude;
        }

        public DbCaseEntry() {}

        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        public Guid DataCollectorId { get; set; }

        public int NumberOfMalesAged5AndOlder { get; set; }

        public int NumberOfFemalesUnder5 { get; set; }

        public int NumberOfFemalesAged5AndOlder { get; set; }

        public int NumberOfMalesUnder5 { get; set; }

        public DateTimeOffset Timestamp { get; set; }

        public int HealthRisk { get; set; }

        public string Origin { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }
}
