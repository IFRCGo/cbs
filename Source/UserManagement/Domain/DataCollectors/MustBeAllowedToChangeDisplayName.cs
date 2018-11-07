using Concepts.DataCollectors;

namespace Domain.DataCollectors
{
    public delegate bool MustBeAllowedToChangeDisplayName(DataCollectorId dataCollector, string displayName);
}