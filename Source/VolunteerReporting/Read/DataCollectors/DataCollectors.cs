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

namespace Read.DataCollectors
{
    public class DataCollectors : IDataCollectors
    {
        readonly IMongoDatabase _database;
        readonly IMongoCollection<DataCollector> _collection;

        public DataCollectors(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<DataCollector>("DataCollector");
        }

        public IEnumerable<DataCollector> GetAll()
        {
            return _collection.FindSync(_ => true).ToList();
        }

        public async Task<IEnumerable<DataCollector>> GetAllAsync()
        {
            var filter = Builders<DataCollector>.Filter.Empty;
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public DataCollector GetById(Guid id)
        {
           return _collection.Find(d => d.Id == id).SingleOrDefault();
        }

        public DataCollector GetByPhoneNumber(string phoneNumber)
        {
            var filter = Builders<DataCollector>.Filter.AnyEq(c => c.PhoneNumbers, phoneNumber);
            return _collection.Find(filter).FirstOrDefault();
        }

        public DataCollectorId GetIdByPhoneNumber(string phoneNumber)
        {
            var filter = Builders<DataCollector>.Filter.AnyEq(c => c.PhoneNumbers, phoneNumber);
            var dataCollectorId = _collection.Find(filter).Project(_ => _.Id).FirstOrDefault();
            if( dataCollectorId == Guid.Empty ) return DataCollectorId.NotSet;
            return dataCollectorId;
        }

        public void Save(DataCollector dataCollector)
        {
            _collection.ReplaceOne(_ => _.Id == dataCollector.Id, dataCollector, new UpdateOptions {IsUpsert = true});
        }

        public async Task SaveAsync(DataCollector dataCollector)
        {
            var filter = Builders<DataCollector>.Filter.Eq(c => c.Id, dataCollector.Id);
            await _collection.ReplaceOneAsync(filter, dataCollector, new UpdateOptions { IsUpsert = true });
        }

        public UpdateResult Update(FilterDefinition<DataCollector> filter, UpdateDefinition<DataCollector> update)
        {
            return _collection.UpdateOne(filter, update);
        }

        public Task<UpdateResult> UpdateAsync(FilterDefinition<DataCollector> filter, UpdateDefinition<DataCollector> update)
        {
            return _collection.UpdateOneAsync(filter, update);
        }

        public void Remove(FilterDefinition<DataCollector> filter)
        {
            _collection.DeleteOne(filter);
        }

        public void Remove(Expression<Func<DataCollector, bool>> filter)
        {
            _collection.DeleteOne(filter);
        }

        public Task RemoveAsync(FilterDefinition<DataCollector> filter)
        {
            return _collection.DeleteOneAsync(filter);
        }

        public Task RemoveAsync(Expression<Func<DataCollector, bool>> filter)
        {
            return _collection.DeleteOneAsync(filter);
        }

        public UpdateResult AddPhoneNumber(FilterDefinition<DataCollector> filter, string number)
        {
            return _collection.UpdateOne(filter, Builders<DataCollector>.Update.AddToSet(d => d.PhoneNumbers, number));
        }

        public UpdateResult AddPhoneNumber(Expression<Func<DataCollector, bool>> filter, string number)
        {
            return _collection.UpdateOne(filter, Builders<DataCollector>.Update.AddToSet(d => d.PhoneNumbers, number));
        }

        public Task<UpdateResult> AddPhoneNumberAsync(FilterDefinition<DataCollector> filter, string number)
        {
            return _collection.UpdateOneAsync(filter, Builders<DataCollector>.Update.AddToSet(d => d.PhoneNumbers, number));
        }

        public Task<UpdateResult> AddPhoneNumberAsync(Expression<Func<DataCollector, bool>> filter, string number)
        {
            return _collection.UpdateOneAsync(filter, Builders<DataCollector>.Update.AddToSet(d => d.PhoneNumbers, number));
        }

        public UpdateResult RemovePhoneNumber(FilterDefinition<DataCollector> filter, string number)
        {
            return _collection.UpdateOne(filter, Builders<DataCollector>.Update.PullFilter(d => d.PhoneNumbers, pn => pn == number));
        }

        public UpdateResult RemovePhoneNumber(Expression<Func<DataCollector, bool>> filter, string number)
        {
            return _collection.UpdateOne(filter, Builders<DataCollector>.Update.PullFilter(d => d.PhoneNumbers, pn => pn == number));
        }

        public Task<UpdateResult> RemovePhoneNumberAsync(FilterDefinition<DataCollector> filter, string number)
        {
            return _collection.UpdateOneAsync(filter, Builders<DataCollector>.Update.PullFilter(d => d.PhoneNumbers, pn => pn == number));
        }

        public Task<UpdateResult> RemovePhoneNumberAsync(Expression<Func<DataCollector, bool>> filter, string number)
        {
            return _collection.UpdateOneAsync(filter, Builders<DataCollector>.Update.PullFilter(d => d.PhoneNumbers, pn => pn == number));
        }

        public UpdateResult ChangeUserInformation(Guid dataCollectorId, string fullName, string displayName, string region, string district)
        {
            return _collection.UpdateOne(d => d.Id == dataCollectorId,
                Builders<DataCollector>.Update.Combine(
                    Builders<DataCollector>.Update.Set(d => d.FullName, fullName),
                    Builders<DataCollector>.Update.Set(d => d.DisplayName, displayName),
                    Builders<DataCollector>.Update.Set(d => d.Region, region),
                    Builders<DataCollector>.Update.Set(d => d.District, district))
            );
        }
    }
}