using Concepts;
using Read.CaseReports;
using Read.DataCollectors;
using Read.HealthRisks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Read.CaseReportsForListing
{
    public class CaseReportForListing
    {
        public Guid Id { get; private set; }
        public CaseReportStatus Status { get; internal set; }
        public DataCollectorId DataCollectorId { get; internal set; }
        public string DataCollectorDisplayName { get; internal set; } = "Unknown"; //QUESTION: Should this be a concept with default value if unknown?
        public HealthRiskId HealthRiskId { get; internal set; }
        public string HealthRisk { get; internal set; } = "Unknown"; //QUESTION: Should this be a concept with default value if unknown?
        public int? NumberOfFemalesOver5 { get; internal set; } //QUESTION: Should this be a concept with default value if unknown?
        public int? NumberOfFemalesUnder5 { get; internal set; } //QUESTION: Should this be a concept with default value if unknown?
        public int? NumberOfMalesOver5 { get; internal set; } //QUESTION: Should this be a concept with default value if unknown?
        public int? NumberOfMalesUnder5 { get; internal set; } //QUESTION: Should this be a concept with default value if unknown?
        public DateTimeOffset Timestamp { get; internal set; }
        public Location Location { get; internal set; }

        //QUESTION: Should we also add text messages that could not be parsed with the parsing error messages? Or is it enough with that status, and another read model should be used in a different view were invalid case reports can be fixed
        

        public CaseReportForListing(Guid id)
        {
            Id = id;
        }
    }
}
