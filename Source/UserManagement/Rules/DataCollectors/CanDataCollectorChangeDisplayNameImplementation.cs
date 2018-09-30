using System.Linq;
using Domain.DataCollectors;
using Infrastructure.Rules;
using Read.DataCollectors;

namespace Rules.DataCollectors
{
    public class CanDataCollectorChangeDisplayNameImplementation : IRuleImplementationFor<CanDataCollectorChangeDisplayName>
    {
        readonly IDataCollectors _dataCollectors;
        public CanDataCollectorChangeDisplayNameImplementation(IDataCollectors dataCollectors) => _dataCollectors = dataCollectors;
        public CanDataCollectorChangeDisplayName Rule => 
            (dataCollector, displayName) => 
                _dataCollectors.Query.SingleOrDefault(d => d.DisplayName == displayName && d.Id != dataCollector) == null;
    }
}