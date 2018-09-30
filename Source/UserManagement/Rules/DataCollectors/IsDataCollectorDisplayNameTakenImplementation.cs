using System.Linq;
using Domain.DataCollectors;
using Infrastructure.Rules;
using Read.DataCollectors;

namespace Rules.DataCollectors
{
    public class IsDataCollectorDisplayNameTakenImplementation : IRuleImplementationFor<IsDataCollectorDisplayNameTaken>
    {
        readonly IDataCollectors _dataCollectors;
        public IsDataCollectorDisplayNameTakenImplementation(IDataCollectors dataCollectors) => _dataCollectors = dataCollectors;
        public IsDataCollectorDisplayNameTaken Rule => (displayName) => _dataCollectors.Query.SingleOrDefault(d => d.DisplayName == displayName) == null;
    }
}