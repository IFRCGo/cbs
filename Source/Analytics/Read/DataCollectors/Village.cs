using Concepts;
using Dolittle.ReadModels;

namespace Read.DataCollectors
{
    public class Village : IReadModel
    {
        public VillageName Id { get; set; }
        public DistrictName District { get; set; }
    }
}
