using Concepts;
using System;
using Dolittle.ReadModels;
using Infrastructure.Read;
using MongoDB.Bson.Serialization;

namespace Read.HealthRisks
{
    public class HealthRisk : IReadModel
    {
        public Guid Id { get; set; }
        public int ReadableId { get; set; }
        public string Name { get; set; }

        public HealthRisk(Guid id)
        {
            Id = id;
        }
    }

    public class HealthRiskClassMap : MongoDbClassMap<HealthRisk>
    {
        public override void Map(BsonClassMap<HealthRisk> cm)
        {
            cm.AutoMap();
            cm.MapIdMember(r => r.Id);
        }

        public override void Register()
        {
            BsonClassMap.RegisterClassMap<HealthRisk>(Map);
        }
    }
}
