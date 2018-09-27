using Concepts.DataCollector;
using Domain.DataCollector.Changing;

namespace Domain.DataCollector
{
    public interface IDataCollectorRules
    {
        bool DataCollectorIsRegistered(DataCollectorId id);

        bool DataCollectorDisplayNameRegistered(string displayName);

        bool DataCollectorCanChangeDisplayName(ChangeBaseInformation command);
    }
}