using Concepts;
using System;
using System.Collections.Generic;

namespace Read.CaseReportsForListing
{
    public class CaseReportForListing
    {
        //TODO: Comment woksin: This whole Read project for casereports needs a rework like what I did for UserManagement
        public Guid Id { get; private set; }
        public CaseReportStatus Status { get; internal set; }
        public DataCollectorId DataCollectorId { get; internal set; }
        public string DataCollectorDisplayName { get; internal set; } = "Unknown"; //TODO: Handle localization for default values or handle in view
        public HealthRiskId HealthRiskId { get; internal set; }
        public string HealthRisk { get; internal set; } = "Unknown"; //TODO: Handle localization for default values or handle in view
        public string Message { get; internal set; }
        public int NumberOfFemalesAgedOver4 { get; internal set; }
        public int NumberOfFemalesAges0To4 { get; internal set; } 
        public int NumberOfMalesAgedOver4 { get; internal set; } 
        public int NumberOfMalesAges0To4 { get; internal set; } 
        public DateTimeOffset Timestamp { get; internal set; }
        public Location Location { get; internal set; }

        public string Origin { get; internal set; }

        public IEnumerable<string> ParsingErrorMessage { get; internal set; }


        public CaseReportForListing(Guid id)
        {
            Id = id;
        }
    }
}
