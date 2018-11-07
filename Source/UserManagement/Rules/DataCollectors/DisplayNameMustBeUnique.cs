using System.Linq;
using Domain.DataCollectors;
using Infrastructure.Rules;
using Read.DataCollectors;

namespace Rules.DataCollectors
{
    public class DisplayNameMustBeUnique : IRuleImplementationFor<Domain.DataCollectors.DisplayNameMustBeUnique>
    {
        readonly IDataCollectors _dataCollectors;
        public DisplayNameMustBeUnique(IDataCollectors dataCollectors) => _dataCollectors = dataCollectors;
        public Domain.DataCollectors.DisplayNameMustBeUnique Rule => (displayName) => !_dataCollectors.Query.Any(d => d.DisplayName == displayName);
    }
}