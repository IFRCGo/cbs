using System;
using Concepts;
using Dolittle.ReadModels;
using Infrastructure.Read;
using MongoDB.Bson.Serialization;

namespace Read.CaseReports
{
    public class CaseReportFromUnknownDataCollector : IReadModel
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string Origin { get; set; }
        public Guid HealthRiskId { get; set; }
        public int NumberOfFemalesAged5AndOlder { get; set; }
        public int NumberOfFemalesUnder5 { get; set; }
        public int NumberOfMalesAged5AndOlder { get; set; }
        public int NumberOfMalesUnder5 { get; set; }
        public DateTimeOffset Timestamp { get; set; }

        public CaseReportFromUnknownDataCollector(Guid id)
        {
            this.Id = id;
        }

    }

    public class CaseReportFromUnknownDataCollectorBsonClassMap : MongoDbClassMap<CaseReportFromUnknownDataCollector>
    {
        public override void Map(BsonClassMap<CaseReportFromUnknownDataCollector> cm)
        {
            cm.AutoMap();
            cm.MapIdMember(r => r.Id);
        }

        public override void Register()
        {
            BsonClassMap.RegisterClassMap<CaseReportFromUnknownDataCollector>(Map);
        }
    }

}