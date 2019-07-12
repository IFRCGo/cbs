using System;
using Concepts;
using Concepts.DataCollectors;
using Dolittle.ReadModels;

namespace Read.DataCollectors
{
    public class DataCollector : IReadModel
    {
        public DataCollectorId Id { get; set; }
        public DateTimeOffset LastActive { get; set; }
        public RegionName Region { get; set; }
        public DistrictName District { get; set; }

        public DataCollector(DataCollectorId id, DateTimeOffset lastActive, RegionName region, DistrictName district)
        {
            Id = id;
            LastActive = lastActive;
            Region = region;
            District = district;
        }
    }
}
