using System;

namespace Web.TestData
{
    public class HealthRiskAggregatedReport
    {
        public Guid HealthRiskId { get; set; }
        public int NumberOfMalesUnder5 { get; set; }
        public int NumberOfMalesAged5AndOlder { get; set; }
        public int NumberOfFemalesUnder5 { get; set; }
        public int NumberOfFemalesAged5AndOlder { get; set; }
    }
}
