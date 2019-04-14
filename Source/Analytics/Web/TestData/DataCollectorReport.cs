using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.TestData
{
    public class DataCollectorReport
    {
        public Guid DataCollectorId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public List<HealthRiskAggregatedReport> HealthRiskAggregatedReports;
    }
}
