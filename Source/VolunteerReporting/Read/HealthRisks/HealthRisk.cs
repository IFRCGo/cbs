using Concepts;
using System;
using Dolittle.ReadModels;
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

    public static class HealthRIskBsonClassMapRegistrator
    {
        public static void Register()
        {
            BsonClassMap.RegisterClassMap<HealthRisk>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(r => r.Id);
            });
        }
    }
}
