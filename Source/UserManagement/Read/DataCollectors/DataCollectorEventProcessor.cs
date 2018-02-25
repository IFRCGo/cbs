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

        public async Task Process(DataCollectorAdded @event)
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

        public async Task Process(DataCollectorUpdated @event)
        {
            var dataCollector = await _dataCollectors.GetByIdAsync(@event.DataCollectorId);

            //TODO: Business Validator should check this(?)
            if (dataCollector == null)
            {
                return;
            }
                
            dataCollector.FullName = @event.FullName;
            dataCollector.DisplayName = @event.DisplayName;
            dataCollector.Location = new Location(@event.LocationLatitude, @event.LocationLongitude);
            dataCollector.YearOfBirth = @event.YearOfBirth;
            dataCollector.NationalSociety = @event.NationalSociety;
            dataCollector.PreferredLanguage = (Language)@event.PreferredLanguage;
            dataCollector.Sex = (Sex)@event.Sex;

            dataCollector.Email = @event.Email; //Todo: Have to change this if datacollector can have multiple emails

            await _dataCollectors.SaveAsync(dataCollector);

        }

        public async Task Process(PhoneNumberAddedToDataCollector @event)
        {
            var dataCollector = await _dataCollectors.GetByIdAsync(@event.DataCollectorId);
            //TODO: Business Validator should check this(?)
            if (dataCollector == null)
            {
                return;
            }
            dataCollector.PhoneNumbers.Add(new PhoneNumber(@event.PhoneNumber));
            await _dataCollectors.SaveAsync(dataCollector);
        }

        public async Task Process(PhoneNumberRemovedFromDataCollector @event)
        {
            var dataCollector = await _dataCollectors.GetByIdAsync(@event.DataCollectorId);
            //TODO: Business Validator should check this(?)
            if (dataCollector == null)
            {
                return;
            }
            dataCollector.PhoneNumbers.Remove(new PhoneNumber(@event.PhoneNumber));
            await _dataCollectors.SaveAsync(dataCollector);
        }

        public async Task Process(CaseReportReceived @event)
        {
            var dataCollector = await _dataCollectors.GetByIdAsync(@event.DataCollectorId);
            dataCollector.LastReportRecievedAt = @event.Timestamp;
            await _dataCollectors.SaveAsync(dataCollector);
        }

        public async Task Process(InvalidReportReceived @event)
        {
            var dataCollector = await _dataCollectors.GetByIdAsync(@event.DataCollectorId);
            dataCollector.LastReportRecievedAt = @event.Timestamp;
            await _dataCollectors.SaveAsync(dataCollector);
        }
    }
}
