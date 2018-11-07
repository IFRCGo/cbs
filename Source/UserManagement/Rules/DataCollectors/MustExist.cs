using Domain.DataCollectors;
using Infrastructure.Rules;
using Read.DataCollectors;

namespace Rules.DataCollectors
{
    public class MustExist : IRuleImplementationFor<Domain.DataCollectors.MustExist>
    {
        readonly IDataCollectors _dataCollectors;
        public MustExist(IDataCollectors dataCollectors) => _dataCollectors = dataCollectors;
        public Domain.DataCollectors.MustExist Rule => (dataCollector) => _dataCollectors.GetById(dataCollector) != null;
    }
}