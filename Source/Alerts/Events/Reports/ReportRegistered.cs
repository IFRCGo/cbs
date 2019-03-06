using Dolittle.Events;
using System;

namespace Events.Reports
{
    public class ReportRegistered : IEvent
    {
        public ReportRegistered(
            Guid reportId, 
            Guid caseReportId, 
            int ageGroup, 
            int sex,
            double latitude,
            double longitude, 
            DateTimeOffset timestamp, 
            Guid dataCollectorId, 
            Guid healthRiskId,
            int healthRiskNumber,
            string originPhoneNumber)
        {
            ReportId = reportId;
            CaseReportId = caseReportId;
            AgeGroup = ageGroup;
            Sex = sex;
            Latitude = latitude;
            Longitude = longitude;
            Timestamp = timestamp;
            DataCollectorId = dataCollectorId;
            HealthRiskId = healthRiskId;
            HealthRiskNumber = healthRiskNumber;
            OriginPhoneNumber = originPhoneNumber;
        }

        public Guid ReportId { get; }
        public Guid CaseReportId { get; }
        public int AgeGroup { get; }
        public int Sex { get; }
        public double Latitude { get; }
        public double Longitude { get; }
        public DateTimeOffset Timestamp { get; }
        public Guid DataCollectorId { get; }
        public Guid HealthRiskId { get; }
        public int HealthRiskNumber { get; }
        public string OriginPhoneNumber { get; }
    }
}
