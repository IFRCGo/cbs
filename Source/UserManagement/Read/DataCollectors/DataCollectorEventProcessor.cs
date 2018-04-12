using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task Process(DataCollectorRegistered @event)
        {
            await _dataCollectors.SaveAsync(new DataCollector(@event.DataCollectorId)
            {
                DisplayName = @event.DisplayName,
                FullName = @event.FullName,
                Location = new Location(@event.LocationLatitude, @event.LocationLongitude),
                YearOfBirth = @event.YearOfBirth,
                NationalSociety = @event.NationalSociety,
                Sex = (Sex)@event.Sex,
                RegisteredAt = @event.RegisteredAt,
                PreferredLanguage = (Language)@event.PreferredLanguage,
                PhoneNumbers = new List<PhoneNumber>()
            });
        }

        public void Process(DataCollectorUpdated @event)
        {
            //TODO: Should be replaced with a new system
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);

            dataCollector.FullName = @event.FullName;
            dataCollector.DisplayName = @event.DisplayName;
            dataCollector.Location = new Location(@event.LocationLatitude, @event.LocationLongitude);
            dataCollector.NationalSociety = @event.NationalSociety;
            dataCollector.PreferredLanguage = (Language)@event.PreferredLanguage;

            _dataCollectors.Save(dataCollector);

        }

        public async Task Process(DataCollectorRemoved @event)
        {
            await _dataCollectors.RemoveAsync(@event.DataCollectorId);
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
