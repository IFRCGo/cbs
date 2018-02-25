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

            dataCollector.PhoneNumbers = new List<PhoneNumber>();
            _dataCollectors.Save(dataCollector);
        }

        public void Process(DataCollectorUpdated @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);

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

            _dataCollectors.Save(dataCollector);

        }

        public void Process(PhoneNumberAddedToDataCollector @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            //TODO: Business Validator should check this(?)
            if (dataCollector == null)
            {
                return;
            }
            dataCollector.PhoneNumbers.Add(new PhoneNumber(@event.PhoneNumber));
            _dataCollectors.Save(dataCollector);
        }

        public void Process(PhoneNumberRemovedFromDataCollector @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId);
            //TODO: Business Validator should check this(?)
            if (dataCollector == null)
            {
                return;
            }
            dataCollector.PhoneNumbers.Remove(new PhoneNumber(@event.PhoneNumber));
            _dataCollectors.Save(dataCollector);
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
