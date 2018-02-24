using System.Collections.Generic;
using Concepts;
using doLittle.Events.Processing;
using Events.DataCollector;
using Events.External;

namespace Read.DataCollectors
{
    public class DataCollectorEventProcessor : ICanProcessEvents 
    {
        private readonly IDataCollectors _dataCollectors;

        public DataCollectorEventProcessor(IDataCollectors dataCollectors)
        {
            _dataCollectors = dataCollectors;
        }

        public async void Process(DataCollectorAdded @event)
        {
            var dataCollector = await _dataCollectors.GetByIdAsync(@event.Id) ?? new DataCollector(@event.Id);
            dataCollector.FullName = @event.FullName;
            dataCollector.DisplayName = @event.DisplayName;
            dataCollector.Location = new Location(@event.LocationLatitude, @event.LocationLongitude);
            dataCollector.YearOfBirth = @event.YearOfBirth;
            dataCollector.NationalSociety = @event.NationalSociety;
            dataCollector.PreferredLanguage = (Language) @event.PreferredLanguage;
            dataCollector.Sex = (Sex) @event.Sex;
            dataCollector.RegisteredAt = @event.RegisteredAt;

            dataCollector.PhoneNumbers = new List<PhoneNumber>();
            await _dataCollectors.SaveAsync(dataCollector);
        }

        public async void Process(PhoneNumberAddedToDataCollector @event)
        {
            var dataCollector = await _dataCollectors.GetByIdAsync(@event.DataCollectorId);
            dataCollector.PhoneNumbers.Add(new PhoneNumber(@event.PhoneNumber));
            await _dataCollectors.SaveAsync(dataCollector);
        }

        public async void Process(PhoneNumberRemovedFromDataCollector @event)
        {
            var dataCollector = await _dataCollectors.GetByIdAsync(@event.DataCollectorId);
            dataCollector.PhoneNumbers.Remove(new PhoneNumber(@event.PhoneNumber));
            await _dataCollectors.SaveAsync(dataCollector);
        }

        public async void Process(CaseReportReceived @event)
        {
            var dataCollector = await _dataCollectors.GetByIdAsync(@event.DataCollectorId);
            dataCollector.LastReportRecievedAt = @event.Timestamp;
            await _dataCollectors.SaveAsync(dataCollector);
        }

        public async void Process(InvalidReportReceived @event)
        {
            var dataCollector = await _dataCollectors.GetByIdAsync(@event.DataCollectorId);
            dataCollector.LastReportRecievedAt = @event.Timestamp;
            await _dataCollectors.SaveAsync(dataCollector);
        }
    }
}
