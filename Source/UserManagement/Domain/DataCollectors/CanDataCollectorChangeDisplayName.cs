using Concepts.DataCollectors;

namespace Domain.DataCollectors
{
    public delegate bool CanDataCollectorChangeDisplayName(DataCollectorId dataCollector, string displayName);
}