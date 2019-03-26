using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.TestData
{
    public class CaseReport
    {
        public Guid DataCollectorId { get; set; }
        public Guid HealthRiskId { get; set; }
        public string Origin { get; set; }
        public int NumberOfMalesUnder5 { get; set; }
        public int NumberOfMalesAged5AndOlder { get; set; }
        public int NumberOfFemalesUnder5 { get; set; }
        public int NumberOfFemalesAged5AndOlder { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTimeOffset Timestamp { get; } = DateTimeOffset.UtcNow;
        public string Message { get; set; }
    }
}
