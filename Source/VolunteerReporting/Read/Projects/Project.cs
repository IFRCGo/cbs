using System;
using Dolittle.ReadModels;
using MongoDB.Bson.Serialization;

namespace Read.Projects
{
    public class Project : IReadModel
    {
    public Guid Id { get; set; }
    public string Name { get; set; }
    }

    public static class ProjectBsonClassMapRegistrator
    {
        public static void Register()
        {
            BsonClassMap.RegisterClassMap<Project>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(r => r.Id);
            });
        }
    }
}
