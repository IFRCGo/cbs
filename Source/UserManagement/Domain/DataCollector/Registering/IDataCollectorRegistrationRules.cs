using Concepts.DataCollector;

namespace Domain.DataCollector.Registering
{
    public interface IDataCollectorRegistrationRules
    {
         bool DataCollectorIsRegistered(DataCollectorId id);
         

    }
}