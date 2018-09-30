using Domain.DataCollectors;
using Infrastructure.Rules;
using Read.DataCollectors;

namespace Rules.DataCollectors
{
    public class DataCollectorExistsImplementation : IRuleImplementationFor<DataCollectorExists>
    {
        readonly IDataCollectors _dataCollectors;
        public DataCollectorExistsImplementation(IDataCollectors dataCollectors) => _dataCollectors = dataCollectors;
        public DataCollectorExists Rule => (dataCollector) => _dataCollectors.GetById(dataCollector) != null;
    }
}