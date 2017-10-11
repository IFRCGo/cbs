using Events.External;

namespace Read
{
    public class DataCollectorEventProcessor : Infrastructure.Events.IEventProcessor
    {
        readonly IDataCollectors _dataCollectors;

        public DataCollectorEventProcessor(IDataCollectors dataCollectors)
        {
            _dataCollectors = dataCollectors;
        }

        public void Process(DataCollectorAdded @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.Id) ?? new DataCollector(@event.Id);
            dataCollector.FirstName = @event.FirstName;
            dataCollector.LastName = @event.LastName;
            dataCollector.MobilePhoneNumbers = @event.MobilePhoneNumbers;
            dataCollector.LocationLatitude = @event.LocationLatitude;
            dataCollector.LocationLongitude = @event.LocationLongitude;
            _dataCollectors.Save(dataCollector);
        }
    }
}