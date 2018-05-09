using System;
using Concepts;
using Dolittle.ReadModels;
using MongoDB.Bson.Serialization;

namespace Read.CaseReports
{
    public class CaseReport : IReadModel
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public Guid DataCollectorId { get; set ; }
        public Guid HealthRiskId { get; set; }
        public int NumberOfFemalesAged5AndOlder { get; set; }
        public int NumberOfFemalesUnder5 { get; set; }
        public int NumberOfMalesAged5AndOlder { get; set; }
        public int NumberOfMalesUnder5 { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public Location Location { get; set; }

        public CaseReport(Guid id)
        {
            Id = id;
        }
    }

    public static class CaseReportBsonClassMapRegistrator
    {
        public static void Register()
        {
            BsonClassMap.RegisterClassMap<CaseReport>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(r => r.Id);
            });
        }
    }
}