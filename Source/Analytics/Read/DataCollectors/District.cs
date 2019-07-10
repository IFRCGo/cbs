using System;
using System.Collections.Generic;
using Concepts;
using Dolittle.ReadModels;

namespace Read.DataCollectors
{
    public class District : IReadModel
    {
        public DistrictName Id { get; set; }
        public RegionName RegionName { get; set; }
        public DistrictName Name { get; set; }
        public List<Guid> DataCollectors { get; set; }
    }
}
