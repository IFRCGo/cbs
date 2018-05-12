using System;
using Dolittle.ReadModels;
using Infrastructure.Read;
using MongoDB.Bson.Serialization;

namespace Read.Projects
{
    public class Project : IReadModel
    {
    public Guid Id { get; set; }
    public string Name { get; set; }
    }

    public class ProjectBsonClassMap : MongoDbClassMap<Project>
    {
        public override void Map(BsonClassMap<Project> cm)
        {
            cm.AutoMap();
            cm.MapIdMember(r => r.Id);
        }

    }
}
