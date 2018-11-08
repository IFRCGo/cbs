using System;

namespace Events.Cases
{
    public class CaseRegistered
    {
        public CaseRegistered(Guid caseId, Guid caseReportId, int ageGroup, int sex)
        {
            CaseId = caseId;
            CaseReportId = caseReportId;
            AgeGroup = ageGroup;
            Sex = sex;
        }

        public Guid CaseId { get; }
        public Guid CaseReportId { get; }
        public int AgeGroup { get; }
        public int Sex { get; }
    }
}
