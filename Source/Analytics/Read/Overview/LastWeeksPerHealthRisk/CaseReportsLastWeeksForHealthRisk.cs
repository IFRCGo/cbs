using Concepts;
using Concepts.HealthRisks;

namespace Read.Overview.LastWeeksPerHealthRisk
{
    public class CaseReportsLastWeeksForHealthRisk
    {
        public HealthRiskName HealthRiskName { get; set; }
        public NumberOfPeople Days0to6 { get; set; }
        public NumberOfPeople Days7to13 { get; set; }
        public NumberOfPeople Days14to20 { get; set; }
        public NumberOfPeople Days21to27 { get; set; }
    }
}
