using Concepts;
using System;
using System.Collections.Generic;
using Dolittle.ReadModels;
using MongoDB.Bson.Serialization;

namespace Read.CaseReportsForListing
{
    public class CaseReportForListing :  IReadModel
    {
        public Guid Id { get; set; }
        public CaseReportStatus Status { get; set; }
        public DataCollectorId DataCollectorId { get; set; }
        public string DataCollectorDisplayName { get; set; }
        public string DataCollectorRegion { get; set; }
        public string DataCollectorDistrict { get; set; }
        public string DataCollectorVillage { get; set; }
        
        public HealthRiskId HealthRiskId { get; set; }
        public string HealthRisk { get; set; }
        public string Message { get; set; }
        public int NumberOfMalesUnder5 { get; set; }
        public int NumberOfMalesAged5AndOlder { get; set; }
        public int NumberOfFemalesUnder5 { get; set; }    
        public int NumberOfFemalesAged5AndOlder { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public Location Location { get; set; }
        public string Origin { get; set; }
        public IEnumerable<string> ParsingErrorMessage { get; set; }

        public CaseReportForListing(Guid id)
        {
            Id = id;
        }
    }
    public static class CaseReportForListingBsonClassMapRegistrator
    {
        public static void Register()
        {
            BsonClassMap.RegisterClassMap<CaseReportForListing>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(r => r.Id);
            });
        }
    }
}
