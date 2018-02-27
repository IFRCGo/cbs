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
            /* Should use a specific command and event for updating
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
            */ 
            await _dataCollectors.SaveAsync(new DataCollector(@event.DataCollectorId)
            {
                DisplayName = @event.DisplayName, FullName = @event.FullName,
                Location = new Location(@event.LocationLatitude, @event.LocationLongitude),
                YearOfBirth = @event.YearOfBirth, NationalSociety = @event.NationalSociety,
                Sex = (Sex)@event.Sex, RegisteredAt = @event.RegisteredAt,
                PreferredLanguage = (Language)@event.PreferredLanguage,
                PhoneNumbers = new List<PhoneNumber>()
            });
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
            dataCollector.NationalSociety = @event.NationalSociety;
            dataCollector.PreferredLanguage = (Language)@event.PreferredLanguage;
            dataCollector.Email = @event.Email;

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
