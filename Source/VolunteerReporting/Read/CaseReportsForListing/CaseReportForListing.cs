using Concepts;
using System;

namespace Read.CaseReportsForListing
{
    public class CaseReportForListing
    {
        public Guid Id { get; private set; }
        public CaseReportStatus Status { get; internal set; }
        public DataCollectorId DataCollectorId { get; internal set; }
        public string DataCollectorDisplayName { get; internal set; } = "Unknown"; //TODO: Handle localization for default values or handle in view
        public HealthRiskId HealthRiskId { get; internal set; }
        public string HealthRisk { get; internal set; } = "Unknown"; //TODO: Handle localization for default values or handle in view
        public string Message { get; internal set; }
        public int NumberOfFemalesOver5 { get; internal set; }
        public int NumberOfFemalesUnder5 { get; internal set; } 
        public int NumberOfMalesOver5 { get; internal set; } 
        public int NumberOfMalesUnder5 { get; internal set; } 
        public DateTimeOffset Timestamp { get; internal set; }
        public Location Location { get; internal set; }
        
        public CaseReportForListing(Guid id)
        {
            Id = id;
        }
    }
}
