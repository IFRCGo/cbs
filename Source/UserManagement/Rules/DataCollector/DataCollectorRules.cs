using System.Linq;
using Concepts.DataCollector;
using Domain.DataCollector;
using Domain.DataCollector.Changing;
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

        public bool DataCollectorCanChangeDisplayName(ChangeBaseInformation command) => 
            _dataCollectors.Query.SingleOrDefault(d => d.DisplayName == command.DisplayName && d.Id != command.DataCollectorId) == null;

        public bool DataCollectorDisplayNameRegistered(string displayName) => 
            _dataCollectors.Query.SingleOrDefault(d => d.DisplayName == displayName) != null;

        public bool DataCollectorIsRegistered(DataCollectorId id) => 
            _dataCollectors.GetById(id) != null;
    }
}