using Concepts.DataCollector;
using Domain.DataCollectors.Changing;

namespace Domain.DataCollectors
{
    public interface IDataCollectorRules
    {
        bool DataCollectorIsRegistered(DataCollectorId id);

        bool DataCollectorDisplayNameRegistered(string displayName);

        bool DataCollectorCanChangeDisplayName(ChangeBaseInformation command);
    }
}