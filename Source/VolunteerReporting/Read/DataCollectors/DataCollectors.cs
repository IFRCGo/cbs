/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Concepts;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using Infrastructure.Read;

namespace Read.DataCollectors
{
    public class DataCollectors : ExtendedReadModelRepositoryFor<DataCollector>, 
        IDataCollectors
    {
       
        public DataCollectors(IMongoDatabase database)
            : base(database, database.GetCollection<DataCollector>("DataCollector"))
        {
        }

        public IEnumerable<DataCollector> GetAll()
        {
            return _collection.FindSync(_ => true).ToList();
        }

        public Task<IEnumerable<DataCollector>> GetAllAsync()
        {
            return GetManyAsync(_ => true);
        }

        public DataCollector GetById(Guid id)
        {
           return GetOne(d => d.Id == id);
        }

        public DataCollector GetByPhoneNumber(string phoneNumber)
        {
            var filter = Builders<DataCollector>.Filter.AnyEq(c => c.PhoneNumbers, phoneNumber);
            return GetOne(filter);
        }

        public DataCollectorId GetIdByPhoneNumber(string phoneNumber)
        {
            var filter = Builders<DataCollector>.Filter.AnyEq(c => c.PhoneNumbers, phoneNumber);
            return GetOne(filter)?.Id ?? DataCollectorId.NotSet;
        }

        public void SaveDataCollector(Guid dataCollectorId, string fullName, string displayName, double locationLatitude,
            double locationLongitude, string region, string district)
        {
            Save(new DataCollector(dataCollectorId)
            {
                DisplayName = displayName,
                FullName = fullName,
                Location = new Location(locationLatitude, locationLongitude),
                PhoneNumbers = new List<string>(),
                Region = region ?? "Unknown",
                District = district ?? "Unknown",
                Village = "Unknown"
            });
        }

        public Task SaveDataCollectorAsync(Guid dataCollectorId, string fullName, string displayName, double locationLatitude,
            double locationLongitude, string region, string district)
        {
            return SaveAsync(new DataCollector(dataCollectorId)
            {
                DisplayName = displayName,
                FullName = fullName,
                Location = new Location(locationLatitude, locationLongitude),
                PhoneNumbers = new List<string>(),
                Region = region ?? "Unknown",
                District = district ?? "Unknown",
                Village = "Unknown"
            });
        }

        public UpdateResult AddPhoneNumber(FilterDefinition<DataCollector> filter, string number)
        {
            return UpdateOne(filter, Builders<DataCollector>.Update.AddToSet(d => d.PhoneNumbers, number));
        }

        public UpdateResult AddPhoneNumber(Expression<Func<DataCollector, bool>> filter, string number)
        {
            return UpdateOne(filter, Builders<DataCollector>.Update.AddToSet(d => d.PhoneNumbers, number));
        }

        public Task<UpdateResult> AddPhoneNumberAsync(FilterDefinition<DataCollector> filter, string number)
        {
            return UpdateOneAsync(filter, Builders<DataCollector>.Update.AddToSet(d => d.PhoneNumbers, number));
        }

        public Task<UpdateResult> AddPhoneNumberAsync(Expression<Func<DataCollector, bool>> filter, string number)
        {
            return UpdateOneAsync(filter, Builders<DataCollector>.Update.AddToSet(d => d.PhoneNumbers, number));
        }

        public UpdateResult RemovePhoneNumber(FilterDefinition<DataCollector> filter, string number)
        {
            return UpdateOne(filter, Builders<DataCollector>.Update.PullFilter(d => d.PhoneNumbers, pn => pn == number));
        }

        public UpdateResult RemovePhoneNumber(Expression<Func<DataCollector, bool>> filter, string number)
        {
            return UpdateOne(filter, Builders<DataCollector>.Update.PullFilter(d => d.PhoneNumbers, pn => pn == number));
        }

        public Task<UpdateResult> RemovePhoneNumberAsync(FilterDefinition<DataCollector> filter, string number)
        {
            return UpdateOneAsync(filter, Builders<DataCollector>.Update.PullFilter(d => d.PhoneNumbers, pn => pn == number));
        }

        public Task<UpdateResult> RemovePhoneNumberAsync(Expression<Func<DataCollector, bool>> filter, string number)
        {
            return UpdateOneAsync(filter, Builders<DataCollector>.Update.PullFilter(d => d.PhoneNumbers, pn => pn == number));
        }

        public UpdateResult ChangeUserInformation(Guid dataCollectorId, string fullName, string displayName, string region, string district)
        {
            return UpdateOne(d => d.Id == dataCollectorId,
                Builders<DataCollector>.Update.Combine(
                    Builders<DataCollector>.Update.Set(d => d.FullName, fullName),
                    Builders<DataCollector>.Update.Set(d => d.DisplayName, displayName),
                    Builders<DataCollector>.Update.Set(d => d.Region, region ?? "Unknown"),
                    Builders<DataCollector>.Update.Set(d => d.District, district ?? "Unknown")
                )
            );
        }

        public Task<UpdateResult> ChangeUserInformationAsync(Guid dataCollectorId, string fullName, string displayName, string region, string district)
        {
            return UpdateOneAsync(d => d.Id == dataCollectorId,
                Builders<DataCollector>.Update.Combine(
                    Builders<DataCollector>.Update.Set(d => d.FullName, fullName),
                    Builders<DataCollector>.Update.Set(d => d.DisplayName, displayName),
                    Builders<DataCollector>.Update.Set(d => d.Region, region ?? "Unknown"),
                    Builders<DataCollector>.Update.Set(d => d.District, district ?? "Unknown"))
            );
        }

        public UpdateResult ChangeLocation(Guid dataCollectorId, double latitude, double longitude)
        {
            return UpdateOne(d => d.Id == dataCollectorId,
                Builders<DataCollector>.Update.Set(d => d.Location, new Location(latitude, longitude)));
        }

        public Task<UpdateResult> ChangeLocationAsync(Guid dataCollectorId, double latitude, double longitude)
        {
            return UpdateOneAsync(d => d.Id == dataCollectorId,
                Builders<DataCollector>.Update.Set(d => d.Location, new Location(latitude, longitude)));
        }
    }
}