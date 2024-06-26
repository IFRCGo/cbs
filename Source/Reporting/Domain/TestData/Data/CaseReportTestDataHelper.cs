using Concepts.CaseReports;
using Concepts.DataCollectors;
using Concepts.HealthRisks;

namespace Domain.TestData.Data
{
    public class CaseReportTestDataHelper
    {
        public string DateLatestTestData { get; set; }
        public CaseReportTestData[] CaseReports { get; set; }
    }

    public class CaseReportTestData
    {
        public CaseReportId Id { get; set; }
        public DataCollectorId DataCollectorId { get; set; }
        public HealthRiskId HealthRiskId { get; set; }
        public string Timestamp { get; set; }
        public string Origin { get; set; }
        public int NumberOfMalesUnder5 { get; set; }
        public int NumberOfMalesAged5AndOlder { get; set; }
        public int NumberOfFemalesUnder5 { get; set; }
        public int NumberOfFemalesAged5AndOlder { get; set; }
        public string Message { get; set; }
    }
}
