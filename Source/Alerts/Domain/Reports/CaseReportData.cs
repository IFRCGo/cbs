using System;

namespace Domain.Reports
{
    /// <summary>
    /// Case report data DTO
    /// </summary>
    public class CaseReportData
    {
        public Guid CaseReportId { get; set; }
        public Guid DataCollectorId { get; set; }
        public Guid HealthRiskId { get; set; }
        public string Message { get; set; }
        public string PhoneNumber { get; set; }
        public int NumberOfMalesUnder5 { get; set; }
        public int NumberOfMalesAged5AndOlder { get; set; }
        public int NumberOfFemalesUnder5 { get; set; }
        public int NumberOfFemalesAged5AndOlder { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
