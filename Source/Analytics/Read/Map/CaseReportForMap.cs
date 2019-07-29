using Concepts;
using Concepts.HealthRisks;

namespace Read.Map
{
    public class CaseReportForMap 
    {
        public HealthRiskName HealthRiskName { get; set; }
        public NumberOfPeople NumberOfPeople { get; set; }
        public Location Location { get; set; }
    }
}
