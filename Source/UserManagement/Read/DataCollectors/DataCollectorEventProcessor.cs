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
            _dataCollectors.Save(new DataCollector(@event.DataCollectorId)
            {
                DisplayName = @event.DisplayName,
                FullName = @event.FullName,
                Location = new Location(@event.LocationLatitude, @event.LocationLongitude),
                YearOfBirth = @event.YearOfBirth,
                Sex = (Sex)@event.Sex,
                RegisteredAt = @event.RegisteredAt,
                PreferredLanguage = (Language)@event.PreferredLanguage,
                PhoneNumbers = new List<PhoneNumber>(),
                District = @event.District,
                Region = @event.Region
            });
        }

        public void Process(DataCollectorUserInformationChanged @event)
        {
            var res = _dataCollectors.UpdateOne(
                Builders<DataCollector>.Filter.Where(d => d.Id == @event.DataCollectorId),
                Builders<DataCollector>.Update.Combine(
                    Builders<DataCollector>.Update.Set(d => d.FullName, @event.FullName),
                    Builders<DataCollector>.Update.Set(d => d.DisplayName, @event.DisplayName),
                    Builders<DataCollector>.Update.Set(d => d.Sex, (Sex) @event.Sex),
                    Builders<DataCollector>.Update.Set(d => d.YearOfBirth, @event.YearOfBirth),
                    Builders<DataCollector>.Update.Set(d => d.District, @event.District),
                    Builders<DataCollector>.Update.Set(d => d.Region, @event.Region))
                );

            if (res.IsModifiedCountAvailable && res.MatchedCount < 1)
            {
                throw new Exception("Data collector with id " + @event.DataCollectorId + " was not found");
            }

        }

        public void Process(DataCollectorLocationChanged @event)
        {
            var res = _dataCollectors.UpdateOne(
                Builders<DataCollector>.Filter.Where(d => d.Id == @event.DataCollectorId),
                Builders<DataCollector>.Update.Set(d => d.Location, new Location(@event.LocationLatitude,@event.LocationLongitude)));

            if (res.IsModifiedCountAvailable && res.MatchedCount < 1)
            {
                throw new Exception("Data collector with id " + @event.DataCollectorId + " was not found");
            }

        }

        public void Process(DataCollectorPreferredLanguageChanged @event)
        {
            var res = _dataCollectors.UpdateOne(
                Builders<DataCollector>.Filter.Where(d => d.Id == @event.DataCollectorId),
                Builders<DataCollector>.Update.Set(d => d.PreferredLanguage, (Language)@event.Language));

            if (res.IsModifiedCountAvailable && res.MatchedCount < 1)
            {
                throw new Exception("Data collector with id " + @event.DataCollectorId + " was not found");
            }
        }

        public void Process(DataCollectorVillageChanged @event)
        {
            var res = _dataCollectors.UpdateOne(
                Builders<DataCollector>.Filter.Where(d => d.Id == @event.DataCollectorId),
                Builders<DataCollector>.Update.Set(d => d.Village, @event.Village));
        }

        public void Process(DataCollectorRemoved @event)
        {
            _dataCollectors.Delete(@event.DataCollectorId);
        }

        public void Process(PhoneNumberAddedToDataCollector @event)
        {
            var res = _dataCollectors.UpdateOne(
                Builders<DataCollector>.Filter.Where(d => d.Id == @event.DataCollectorId),
                Builders<DataCollector>.Update.AddToSet(d => d.PhoneNumbers, new PhoneNumber(@event.PhoneNumber)));

            if (res.IsModifiedCountAvailable && res.MatchedCount < 1)
            {
                throw new Exception("Data collector with id " + @event.DataCollectorId + " was not found");
            }
        }

        public void Process(PhoneNumberRemovedFromDataCollector @event)
        {
            var res = _dataCollectors.UpdateOne(
                Builders<DataCollector>.Filter.Where(d => d.Id == @event.DataCollectorId),
                Builders<DataCollector>.Update.PullFilter(d => d.PhoneNumbers, pn => pn.Value == @event.PhoneNumber));

            if (res.IsModifiedCountAvailable && res.MatchedCount < 1)
            {
                throw new Exception("Data collector with id " + @event.DataCollectorId + " was not found");
            }
        }

        public void Process(CaseReportReceived @event)
        {
            var res = _dataCollectors.UpdateOne(
                Builders<DataCollector>.Filter.Where(d => d.Id == @event.DataCollectorId),
                Builders<DataCollector>.Update.Set(d => d.LastReportRecievedAt, @event.Timestamp));

            if (res.IsModifiedCountAvailable && res.MatchedCount < 1)
            {
                throw new Exception("Data collector with id " + @event.DataCollectorId + " was not found");
            }
        }

        public void Process(InvalidReportReceived @event)
        {
            var res = _dataCollectors.UpdateOne(
                Builders<DataCollector>.Filter.Where(d => d.Id == @event.DataCollectorId),
                Builders<DataCollector>.Update.Set(d => d.LastReportRecievedAt, @event.Timestamp));

            if (res.IsModifiedCountAvailable && res.MatchedCount < 1)
            {
                throw new Exception("Data collector with id " + @event.DataCollectorId + " was not found");
            }
        }
    }
}
