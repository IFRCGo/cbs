/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq.Expressions;
using Concepts.DataCollector;

namespace Read.DataCollectors
{
    public class DataCollectors : ExtendedReadModelRepositoryFor<DataCollector>, 
        IDataCollectors
    {
       
        public DataCollectors(IMongoDatabase database)
            : base(database)
        {
        }

        public IEnumerable<DataCollector> GetAll()
        {
            return GetMany(_ => true);
        }

        public DataCollector GetById(DataCollectorId id)
        {
           return GetOne(d => d.Id == id);
        }

        public DataCollector GetByPhoneNumber(string phoneNumber)
        {
            var filter = Builders<DataCollector>.Filter.AnyEq(c => c.PhoneNumbers, (PhoneNumber)phoneNumber);
            return GetOne(filter);
        }

        public DataCollectorId GetIdByPhoneNumber(string phoneNumber)
        {
            var filter = Builders<DataCollector>.Filter.AnyEq(dc => dc.PhoneNumbers, (PhoneNumber)phoneNumber);
            return GetOne(filter)?.Id ?? DataCollectorId.NotSet;
        }

        public void SaveDataCollector(DataCollectorId dataCollectorId, string fullName, string displayName, double locationLatitude,
            double locationLongitude, string region, string district)
        {
            Update(new DataCollector(dataCollectorId)
            {
                DisplayName = displayName,
                FullName = fullName,
                Location = new Location(locationLatitude, locationLongitude),
                PhoneNumbers = new List<PhoneNumber>(),
                Region = region ?? "Unknown",
                District = district ?? "Unknown",
                Village = "Unknown"
            });
        }

        public UpdateResult AddPhoneNumber(FilterDefinition<DataCollector> filter, string number)
        {
            return Update(filter, Builders<DataCollector>.Update.AddToSet(d => d.PhoneNumbers, (PhoneNumber)number));
        }

        public UpdateResult AddPhoneNumber(Expression<Func<DataCollector, bool>> filter, string number)
        {
            return Update(filter, Builders<DataCollector>.Update.AddToSet(d => d.PhoneNumbers, (PhoneNumber)number));
        }

        public UpdateResult RemovePhoneNumber(FilterDefinition<DataCollector> filter, string number)
        {
            return Update(filter, Builders<DataCollector>.Update.PullFilter(d => d.PhoneNumbers, pn => pn == number));
        }

        public UpdateResult RemovePhoneNumber(Expression<Func<DataCollector, bool>> filter, string number)
        {
            return Update(filter, Builders<DataCollector>.Update.PullFilter(d => d.PhoneNumbers, pn => pn == number));
        }

        public UpdateResult ChangeUserInformation(DataCollectorId dataCollectorId, string fullName, string displayName, string region, string district)
        {
            return Update(d => d.Id == dataCollectorId, Builders<DataCollector>.Update.Combine(
                    Builders<DataCollector>.Update.Set(d => d.FullName, fullName),
                    Builders<DataCollector>.Update.Set(d => d.DisplayName, displayName),
                    Builders<DataCollector>.Update.Set(d => d.Region, region ?? "Unknown"),
                    Builders<DataCollector>.Update.Set(d => d.District, district ?? "Unknown")
                )
            );
        }

        public UpdateResult ChangeLocation(DataCollectorId dataCollectorId, double latitude, double longitude)
        {
            return Update(d => d.Id == dataCollectorId,
                Builders<DataCollector>.Update.Set(d => d.Location, new Location(latitude, longitude)));
        }
    }
}