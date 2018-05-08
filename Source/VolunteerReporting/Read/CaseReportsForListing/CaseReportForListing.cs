using Concepts;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Dolittle.ReadModels;

namespace Read.CaseReportsForListing
{
    public class CaseReportForListing :  IReadModel, IHaveReadModelIdOf<Guid>
    {
        public Guid Id { get; set; }
        public CaseReportStatus Status { get; set; }
        public DataCollectorId DataCollectorId { get; set; }
        public string DataCollectorDisplayName { get; set; } = "Unknown"; //TODO: Handle localization for default values or handle in view
        public string DataCollectorRegion { get; internal set; } = "Unknown"; //TODO: Handle localization for default values or handle in view
        public string DataCollectorDistrict { get; internal set; } = "Unknown"; //TODO: Handle localization for default values or handle in view
        public string DataCollectorVillage { get; internal set; } = "Unknown"; //TODO: Handle localization for default values or handle in view
        
        public HealthRiskId HealthRiskId { get; set; }
        public string HealthRisk { get; set; } = "Unknown"; //TODO: Handle localization for default values or handle in view
        public string Message { get; set; }
        public int NumberOfMalesUnder5 { get; set; }
        public int NumberOfMalesAged5AndOlder { get; set; }
        public int NumberOfFemalesUnder5 { get; set; }    
        public int NumberOfFemalesAged5AndOlder { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public Location Location { get; set; }
        public string Origin { get; set; }
        public IEnumerable<string> ParsingErrorMessage { get; set; }

        //TODO: Remove properties below from model once data is migrated to new property names or can be removed
        //This feels dirty. Waiting for input from @einari on how to handle backwardscompability better
        [Obsolete]
        public int? NumberOfFemalesAgedOver4 { get; set; }
        [Obsolete]
        public int? NumberOfFemalesAges0To4 { get; set; }
        [Obsolete]
        public int? NumberOfMalesAgedOver4 { get; set; }
        [Obsolete]
        public int? NumberOfMalesAges0To4 { get; set; }

        public CaseReportForListing(Guid id)
        {
            Id = id;
        }

        //This is going to get messy if we do many breaking changes. How should this be done @einari?
        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            NumberOfMalesUnder5 = NumberOfMalesAges0To4 ?? NumberOfMalesUnder5;
            NumberOfMalesAged5AndOlder = NumberOfMalesAgedOver4 ?? NumberOfMalesAged5AndOlder;
            NumberOfFemalesUnder5 = NumberOfFemalesAges0To4 ?? NumberOfFemalesUnder5;
            NumberOfFemalesAged5AndOlder = NumberOfFemalesAgedOver4 ?? NumberOfFemalesAged5AndOlder;
        }
    }
}
