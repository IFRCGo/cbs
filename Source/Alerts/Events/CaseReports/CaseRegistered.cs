using Dolittle.Events;
using System;

namespace Events.CaseReports
{
    public class CaseRegistered : IEvent
    {
        public CaseRegistered(
            Guid caseId, 
            Guid caseReportId, 
            int ageGroup, 
            int sex,
            double latitude,
            double longitude, 
            DateTimeOffset timestamp, 
            Guid dataCollectorId, 
            Guid healthRiskId)
        {
            CaseId = caseId;
            CaseReportId = caseReportId;
            AgeGroup = ageGroup;
            Sex = sex;
            Latitude = latitude;
            Longitude = longitude;
            Timestamp = timestamp;
            DataCollectorId = dataCollectorId;
            HealthRiskId = healthRiskId;
        }

        public Guid CaseId { get; }
        public Guid CaseReportId { get; }
        public int AgeGroup { get; }
        public int Sex { get; }
        public double Latitude { get; }
        public double Longitude { get; }
        public DateTimeOffset Timestamp { get; }
        public Guid DataCollectorId { get; }
        public Guid HealthRiskId { get; }
    }
}
