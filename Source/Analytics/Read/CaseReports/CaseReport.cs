using System;

namespace Read.CaseReports
{       
    public class CaseReport : BaseReadModel
    {
        public Guid CaseReportId { get; set; }
        public Guid DataCollectorId { get; set; }
        public Guid HealthRisk { get; set; }
        public string Origin { get; set; }
        public string Message { get; set; }
        public int NumberOfMalesUnder5 { get; set; }
        public int NumberOfMalesAged5AndOlder { get; set; }
        public int NumberOfFemalesUnder5 { get; set; }
        public int NumberOfFemalesAged5AndOlder { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; } 
        public DateTimeOffset Timestamp { get; set; }

        public CaseReport(Guid caseReportId, Guid dataCollectorId, Guid healthRisk,
            string origin, string message, int numberOfMalesUnder5, int numberOfMalesAged5AndOlder,
            int numberOfFemalesUnder5, int numberOfFemalesAged5AndOlder, double longitude,
            double latitude, DateTimeOffset timestamp)
        {
            CaseReportId = caseReportId;
            DataCollectorId = dataCollectorId;
            HealthRisk = healthRisk;
            Origin = origin;
            Message = message;
            NumberOfMalesUnder5 = numberOfMalesUnder5;
            NumberOfMalesAged5AndOlder = numberOfMalesAged5AndOlder;
            NumberOfFemalesUnder5 = numberOfFemalesUnder5;
            NumberOfFemalesAged5AndOlder = numberOfFemalesAged5AndOlder;
            Longitude = longitude;
            Latitude = latitude;
            Timestamp = timestamp;
        }
    }
}