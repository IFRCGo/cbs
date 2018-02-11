using Concepts;
using doLittle.Events.Processing;
using Events;
using Events.External;

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
            dataCollector.FullName = @event.FullName;
            dataCollector.DisplayName = @event.DisplayName;
            dataCollector.Location = new Location(@event.LocationLatitude, @event.LocationLongitude);
            dataCollector.YearOfBirth = @event.YearOfBirth;
            dataCollector.NationalSociety = @event.NationalSociety;
            dataCollector.PreferredLanguage = (Language) @event.PreferredLanguage;
            dataCollector.Sex = (Sex) @event.Sex;
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

        public void Process(CaseReportReceived @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.LastReportRecievedAt = @event.Timestamp;
            _dataCollectors.Save(dataCollector);
        }

        public void Process(InvalidReportReceived @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            dataCollector.LastReportRecievedAt = @event.Timestamp;
            _dataCollectors.Save(dataCollector);
        }
    }
}
