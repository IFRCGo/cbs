using System;
using System.Collections.Generic;

namespace Web.TestData
{
    public class DataOwners
    {
        public Guid DataOwnerId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; }
        public List<Guid> DataCollectors { get; set; }
    }
}
