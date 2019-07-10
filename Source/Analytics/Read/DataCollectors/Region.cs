using Concepts;
using Dolittle.ReadModels;

namespace Read.DataCollectors
{
    public class Region : IReadModel
    {
        public RegionName Id { get; set; }
        public RegionName Name { get; set; }
    }
}
