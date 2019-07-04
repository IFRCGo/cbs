using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Reporting.DataCollectors;
using Dolittle.Runtime.Events;


namespace Read.DataCollectors
{
    public class DataCollectorRegisteredProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<DataCollector> _repositoryForDataCollector;

        public DataCollectorRegisteredProcessor(
            IReadModelRepositoryFor<DataCollector> repositoryForDataCollector            
        )
        {
            _repositoryForDataCollector = repositoryForDataCollector;
        }
        
        [EventProcessor("836314c2-20e2-174e-b629-00da4a2c8159")]
        public void Process(DataCollectorRegistered @event, EventSourceId dataCollectorId)
        { 
            var dataCollector = _repositoryForDataCollector.GetById(dataCollectorId.Value); //why do we do this?

            dataCollector = new DataCollector()
                {
                    Id = dataCollectorId.Value,
                    DisplayName = @event.DisplayName,
                    Location = new Concepts.Location(@event.LocationLatitude, @event.LocationLongitude),
                    Region = @event.Region,
                    District = @event.District,
                    Village = null //Event currently not supporting Village
                };
            _repositoryForDataCollector.Insert(dataCollector);
        }
        
    }
}