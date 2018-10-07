using Domain.DataCollectors;
using Infrastructure.Rules;
using Read.DataCollectors;

namespace Rules.DataCollectors
{
    public class CantExist : IRuleImplementationFor<Domain.DataCollectors.CantExist>
    {
        readonly IDataCollectors _dataCollectors;
        public CantExist(IDataCollectors dataCollectors) => _dataCollectors = dataCollectors;
        public Domain.DataCollectors.CantExist Rule => (dataCollector) => _dataCollectors.GetById(dataCollector) == null;
    }
}