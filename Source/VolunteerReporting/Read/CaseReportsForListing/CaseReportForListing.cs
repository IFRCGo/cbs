using Concepts;
using System;
using System.Collections.Generic;
using Dolittle.ReadModels;
using Infrastructure.Read.MongoDb;

namespace Read.CaseReportsForListing
{
    public class CaseReportForListing :  IReadModel, IHaveExtraElements
    {
        public Guid Id { get; set; }
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

        public CaseReportForListing(Guid id)
        {
            Id = id;
        }

        // if(ExtraElements.TryGetValue("NumberOfMalesAgedOver4", out males5AndOlder))
            // {
            //     ExtraElements.Remove("NumberOfMalesAgedOver4");
            //     NumberOfMalesAged5AndOlder = (int)males5AndOlder;
            // }
            // if(ExtraElements.TryGetValue("NumberOfMalesAges0To4", out malesUnder5))
            // {
            //     ExtraElements.Remove("NumberOfMalesAges0To4");
            //     NumberOfMalesUnder5 = (int)malesUnder5;
            // }

            // if(ExtraElements.TryGetValue("NumberOfFemalesAgedOver4", out females5AndOlder))
            // {
            //     ExtraElements.Remove("NumberOfMalesAgedOver4");
            //     NumberOfFemalesAged5AndOlder = (int)females5AndOlder;
            // }
            // if(ExtraElements.TryGetValue("NumberOfFemalesAges0To4", out femalesUnder5))
            // {
            //     ExtraElements.Remove("NumberOfMalesAges0To4");
            //     NumberOfFemalesUnder5 = (int)femalesUnder5;
            // }
    }
}
