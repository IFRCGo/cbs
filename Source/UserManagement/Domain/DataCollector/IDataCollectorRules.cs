using Concepts.DataCollector;

namespace Domain.DataCollector
{
    public interface IDataCollectorRules
    {
        bool DataCollectorIsRegistered(DataCollectorId id);

    }
}