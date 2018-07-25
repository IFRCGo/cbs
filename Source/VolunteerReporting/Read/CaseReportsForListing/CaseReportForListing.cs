using Concepts;
using System;
using System.Collections.Generic;
using Dolittle.ReadModels;
using Infrastructure.Read.MongoDb;
using Concepts.DataCollector;
using Concepts.CaseReport;
using Concepts.HealthRisk;

namespace Read.CaseReportsForListing
{
    public class CaseReportForListing :  IReadModel, IHaveExtraElements
    {
        public CaseReportId Id { get; set; }
        public IDictionary<string, object> ExtraElements { get; set; }

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

        public CaseReportForListing(CaseReportId id)
        {
            Id = id;
        }
    }
}
