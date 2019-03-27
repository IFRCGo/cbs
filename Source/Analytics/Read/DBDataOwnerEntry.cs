using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Read
{
    public class DbDataOwnerEntry
    {
        public DbDataOwnerEntry(Guid dataOwnerId, string name, double longitude, double latitude, List<Guid> dataCollectors)
        {
            DataOwnerId = dataOwnerId;
            Name = name;
            Longitude = longitude;
            Latitude = latitude;
            DataCollectors = dataCollectors;
        }
        
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        public Guid DataOwnerId { get; set; }
        
        public string Name { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public List<Guid> DataCollectors { get; set; }
    }
}
