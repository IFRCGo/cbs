using Dolittle.Events;
using Dolittle.Artifacts;

namespace Events.Admin.DataCollectors
{
    [Artifact("899f24ac-860d-4dae-ae90-938ac12e5226", 1)]
    public class DataCollectorRegistered : IEvent
    {
        public string Region { get; }
        public string District { get; }

        public DataCollectorRegistered (
                string region,
                string district
            )
        {
            Region = region;
            District = district;
        }
    }
}
