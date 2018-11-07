using System.Linq;
using Domain.DataCollectors;
using Infrastructure.Rules;
using Read.DataCollectors;

namespace Rules.DataCollectors
{
    public class CanDataCollectorChangeDisplayName : IRuleImplementationFor<Domain.DataCollectors.MustBeAllowedToChangeDisplayName>
    {
        readonly IDataCollectors _dataCollectors;
        public CanDataCollectorChangeDisplayName(IDataCollectors dataCollectors) => _dataCollectors = dataCollectors;
        public Domain.DataCollectors.MustBeAllowedToChangeDisplayName Rule => 
            (dataCollector, displayName) => 
                _dataCollectors.Query.SingleOrDefault(d => d.DisplayName == displayName && d.Id != dataCollector) == null;
    }
}