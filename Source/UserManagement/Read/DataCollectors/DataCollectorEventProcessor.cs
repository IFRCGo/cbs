using System;
using System.Collections.Generic;
using System.Globalization;
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

        public void Process(DataCollectorRegistered @event)
        {
            _dataCollectors.Insert(new DataCollector(@event.DataCollectorId)
            {
                DisplayName = @event.DisplayName,
                FullName = @event.FullName,
                Location = new Location(@event.LocationLatitude, @event.LocationLongitude),
                YearOfBirth = @event.YearOfBirth,
                Sex = (Sex)@event.Sex,
                RegisteredAt = @event.RegisteredAt,
                RegisteredBy = @event.RegisteredBy,
                PreferredLanguage = (Language)@event.PreferredLanguage,
                PhoneNumbers = new List<PhoneNumber>(),
                District = @event.District,
                Region = @event.Region
            });
        }

        public void Process(DataCollectorUserInformationChanged @event)
        {
            _dataCollectors.Update(d => d.Id == @event.DataCollectorId, Builders<DataCollector>.Update.Combine(
                    Builders<DataCollector>.Update.Set(d => d.FullName, @event.FullName),
                    Builders<DataCollector>.Update.Set(d => d.DisplayName, @event.DisplayName),
                    Builders<DataCollector>.Update.Set(d => d.Sex, (Sex) @event.Sex),
                    Builders<DataCollector>.Update.Set(d => d.YearOfBirth, @event.YearOfBirth),
                    Builders<DataCollector>.Update.Set(d => d.District, @event.District),
                    Builders<DataCollector>.Update.Set(d => d.Region, @event.Region))
                    );
            
        }

        public void Process(DataCollectorLocationChanged @event)
        {
            _dataCollectors.Update(d => d.Id == @event.DataCollectorId,
                Builders<DataCollector>.Update.Set(d => d.Location, new Location(@event.LocationLatitude,@event.LocationLongitude)));

        }

        public void Process(DataCollectorPreferredLanguageChanged @event)
        {
            _dataCollectors.Update(d => d.Id == @event.DataCollectorId,
                Builders<DataCollector>.Update.Set(d => d.PreferredLanguage, (Language)@event.Language));
            
        }

        public void Process(DataCollectorVillageChanged @event)
        {
            _dataCollectors.Update(d => d.Id == @event.DataCollectorId,
                Builders<DataCollector>.Update.Set(d => d.Village, @event.Village));
        }

        public void Process(DataCollectorRemoved @event)
        {
            _dataCollectors.Delete(d => d.Id == @event.DataCollectorId);
        }

        public void Process(PhoneNumberAddedToDataCollector @event)
        {
            _dataCollectors.Update(d => d.Id == @event.DataCollectorId,
                Builders<DataCollector>.Update.AddToSet(d => d.PhoneNumbers, new PhoneNumber(@event.PhoneNumber)));
            
        }

        public void Process(PhoneNumberRemovedFromDataCollector @event)
        {
            _dataCollectors.Update(d => d.Id == @event.DataCollectorId,
                Builders<DataCollector>.Update.PullFilter(d => d.PhoneNumbers, pn => pn.Value == @event.PhoneNumber));
            
        }

        public void Process(CaseReportReceived @event)
        {
            _dataCollectors.Update(d => d.Id == @event.DataCollectorId,
                Builders<DataCollector>.Update.Set(d => d.LastReportRecievedAt, @event.Timestamp));
            
        }

        public void Process(InvalidReportReceived @event)
        {
            _dataCollectors.Update(d => d.Id == @event.DataCollectorId,
                Builders<DataCollector>.Update.Set(d => d.LastReportRecievedAt, @event.Timestamp));
        }
    }
}
