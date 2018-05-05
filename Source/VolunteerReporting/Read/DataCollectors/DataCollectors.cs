/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Concepts;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;

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
    }
}