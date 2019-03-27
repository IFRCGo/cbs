using System;
using System.Collections.Generic;

namespace Web.TestData
{
    public class DataOwnerReport
    {
        public Guid DataOwnerId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public List<DataCollectorReport> DataCollectorReports { get; set; }
    }
}
