using Concepts;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Read.CaseReportsForListing
{
    public class CaseReportForListing
    {
        
        //TODO: Comment woksin: This whole Read project for casereports needs a rework like what I did for UserManagement
        public Guid Id { get; private set; }
        public CaseReportStatus Status { get; internal set; }
        public DataCollectorId DataCollectorId { get; internal set; }
        public string DataCollectorDisplayName { get; internal set; } = "Unknown"; //TODO: Handle localization for default values or handle in view
        public string DataCollectorRegion { get; internal set; } = "Unknown"; //TODO: Handle localization for default values or handle in view
        public string DataCollectorDistrict { get; internal set; } = "Unknown"; //TODO: Handle localization for default values or handle in view
        public string DataCollectorVillage { get; internal set; } = "Unknown"; //TODO: Handle localization for default values or handle in view
        public HealthRiskId HealthRiskId { get; internal set; }
        public string HealthRisk { get; internal set; } = "Unknown"; //TODO: Handle localization for default values or handle in view
        public string Message { get; internal set; }
        //TODO: Remove custom get logic once obsolete properties can be removed
        public int NumberOfMalesUnder5 { get; internal set; }
        public int NumberOfMalesAged5AndOlder { get; internal set; }
        public int NumberOfFemalesUnder5 { get; internal set; }    
        public int NumberOfFemalesAged5AndOlder { get; internal set; }
        public DateTimeOffset Timestamp { get; internal set; }
        public Location Location { get; internal set; }
        public string Origin { get; internal set; }
        public IEnumerable<string> ParsingErrorMessage { get; internal set; }
        
        //TODO: Remove properties below from model once data is migrated to new property names or can be removed
        //This feels dirty. Waiting for input from @einari on how to handle backwardscompability better
        [Obsolete]
        public int? NumberOfFemalesAgedOver4 { get; internal set; }
        [Obsolete]
        public int? NumberOfFemalesAges0To4 { get; internal set; }
        [Obsolete]
        public int? NumberOfMalesAgedOver4 { get; internal set; }
        [Obsolete]
        public int? NumberOfMalesAges0To4 { get; internal set; }
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
