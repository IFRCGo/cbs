using Concepts.DataCollector;
using Domain.DataCollector;
using Read.DataCollectors;

namespace Rules.DataCollector
{
    public class DataCollectorRules : IDataCollectorRules
    {
        readonly IDataCollectors _dataCollectors;

        public DataCollectorRules(IDataCollectors dataCollectors)
        {
            _dataCollectors = dataCollectors;
        }
        public bool DataCollectorIsRegistered(DataCollectorId id)
        {
            return _dataCollectors.GetById(id) != null;
        }
    }
}