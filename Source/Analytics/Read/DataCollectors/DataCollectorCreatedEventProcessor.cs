using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Reporting.DataCollectors;

namespace Read.DataCollectors
{
    public class DataCollectorCreatedEventProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<DataCollector> _repositoryForDataCollectors;

        public DataCollectorCreatedEventProcessor(
            IReadModelRepositoryFor<DataCollector> repositoryForDataCollectors     
        )
        {
            _repositoryForDataCollectors = repositoryForDataCollectors;
        }
        
        [EventProcessor("95dca4f9-3a14-ed6c-cca5-0fa25e1e620a")]
        public void Process(DataCollectorRegistered @event)
        { 
            var dataCollector = _repositoryForDataCollectors.GetById(@event.DataCollectorId);

                dataCollector = new DataCollector(@event.EventSourceId) //dataCollectorId
                {
                    DisplayName = @event.DisplayName,
                    Location = new Concepts.Location(@event.LocationLatitude, @event.LocationLongitude),
                    Region = @event.Region,
                    District = @event.District
                    //, Village = @event.Village
                };
            _repositoryForDataCollectors.Insert(dataCollector);
        }
        
    }
}