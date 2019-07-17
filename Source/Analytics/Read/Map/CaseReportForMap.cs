using Concepts;
using Concepts.HealthRisk;

namespace Read.Map
{
    public class CaseReportForMap 
    {
        public HealthRiskName HealthRiskName { get; set; }
        public NumberOfPeople NumberOfPeople { get; set; }
        public Location Location { get; set; }
    }
}