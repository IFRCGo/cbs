using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Concepts;
using Dolittle.Events.Processing;
using Events.DataCollector;
using Events.External;
using MongoDB.Driver;

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
                Sex = (Sex)@event.Sex,
                RegisteredAt = @event.RegisteredAt,
                PreferredLanguage = (Language)@event.PreferredLanguage,
                PhoneNumbers = new List<PhoneNumber>()
            });
        }

        public void Process(DataCollectorUserInformationChanged @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId) ?? 
                                throw new Exception("Data collector with id " + @event.DataCollectorId + " was not found");

            dataCollector.FullName = @event.FullName;
            dataCollector.DisplayName = @event.DisplayName;
            dataCollector.Sex = (Sex)@event.Sex;
            dataCollector.YearOfBirth = @event.YearOfBirth;
            
            _dataCollectors.Save(dataCollector);

        }

        public void Process(DataCollectorLocationChanged @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId) ??
                                throw new Exception("Data collector with id " + @event.DataCollectorId + " was not found");

            dataCollector.Location = new Location(@event.LocationLatitude, @event.LocationLongitude);

            _dataCollectors.Save(dataCollector);
        }

        public void Process(DataCollectorPrefferedLanguageChanged @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId) ??
                                throw new Exception("Data collector with id " + @event.DataCollectorId + " was not found");

            dataCollector.PreferredLanguage = (Language) @event.Language;

            _dataCollectors.Save(dataCollector);
        }

        public async Task Process(DataCollectorRemoved @event)
        {
            await _dataCollectors.RemoveAsync(@event.DataCollectorId);
        }

        public void Process(PhoneNumberAddedToDataCollector @event)
        {
            // Threadsafe updating
            _dataCollectors.UpdateSafe(Builders<DataCollector>.Filter.Where(d => d.DataCollectorId == @event.DataCollectorId),
                Builders<DataCollector>.Update.Push(d => d.PhoneNumbers,new PhoneNumber(@event.PhoneNumber)));
        }

        public void Process(PhoneNumberRemovedFromDataCollector @event)
        {
            //Threadsafe updating
            _dataCollectors.UpdateSafe(Builders<DataCollector>.Filter.Where(d => d.DataCollectorId == @event.DataCollectorId),
                Builders<DataCollector>.Update.PullFilter(d => d.PhoneNumbers, pn => pn.Value == @event.PhoneNumber));

        }

        public void Process(CaseReportReceived @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId) ??
                                throw new Exception("Data collector with id " + @event.DataCollectorId + " was not found"); ;
            dataCollector.LastReportRecievedAt = @event.Timestamp;
            _dataCollectors.Save(dataCollector);
        }

        public void Process(InvalidReportReceived @event)
        {
            var dataCollector = _dataCollectors.GetById(@event.DataCollectorId) ??
                                throw new Exception("Data collector with id " + @event.DataCollectorId + " was not found"); ;
            dataCollector.LastReportRecievedAt = @event.Timestamp;
            _dataCollectors.Save(dataCollector);
        }
    }
}
