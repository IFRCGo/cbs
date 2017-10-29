using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Read.ProjectFeatures
{
    public class ProjectHealthRiskVersions : IProjectHealthRiskVersions
    {
        readonly IMongoCollection<ProjectHealthRiskVersion> _collection;
        readonly IMongoDatabase _database;

        public ProjectHealthRiskVersions(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<ProjectHealthRiskVersion>("ProjectHealthRiskVersion");
        }

        public void Append(Guid projectId, ProjectHealthRisk healthRisk, DateTimeOffset effectiveFromTime)
        {
            _collection.InsertOne(new ProjectHealthRiskVersion()
            {
                Id = Guid.NewGuid(),
                EffectiveFromTime = effectiveFromTime,
                HealthRisk = healthRisk,
                ProjectId = projectId
            });
        }

        public IEnumerable<ProjectHealthRiskVersion> GetByProjectIdAndHealthRiskId(Guid projectId, Guid healthRiskId)
        {
            var projectFilter = Builders<ProjectHealthRiskVersion>.Filter.Eq(v => v.ProjectId, projectId);
            var healthRiskFilter = Builders<ProjectHealthRiskVersion>.Filter.Eq(v => v.HealthRisk.HealthRiskId, healthRiskId);
            var filter = Builders<ProjectHealthRiskVersion>.Filter.And(projectFilter, healthRiskFilter);
            return _collection.Find(filter).ToEnumerable();
        }
    }
}
