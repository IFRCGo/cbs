using Concepts;
using doLittle.Events.Processing;
using Events;

namespace Read.DataCollectors
{
    public class DataCollectorEventProcessor : ICanProcessEvents 
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
            dataCollector.Location = new Location(@event.LocationLatitude, @event.LocationLongitude);
            dataCollector.Age = @event.Age;
            dataCollector.NationalSociety = @event.NationalSociety;
            dataCollector.PreferredLanguage = @event.PreferredLanguage;
            dataCollector.Sex = @event.Sex;
            dataCollector.RegisteredAt = @event.RegisteredAt;
            _dataCollectors.Save(dataCollector);
        }

        public void Process(PhoneNumberAddedToDataCollector @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.PhoneNumbers.Add(new PhoneNumber(@event.PhoneNumber));
            _dataCollectors.Save(dataCollector);
        }

        public void Process(PhoneNumberRemovedFromDataCollector @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.PhoneNumbers.Remove(new PhoneNumber(@event.PhoneNumber));
            _dataCollectors.Save(dataCollector);
        }

        //TODO: Process CaseReportRecieved to find the time for last report recieved
    }
}
