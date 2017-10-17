/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using MongoDB.Driver;

namespace Read
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

        public DataCollector GetById(Guid id)
        {
           return _collection.Find(d => d.Id == id).SingleOrDefault();
        }

        public DataCollector GetByPhoneNumber(string phoneNumber)
        {
            var filter = Builders<DataCollector>.Filter.AnyEq(c => c.PhoneNumbers, phoneNumber);
            return _collection.Find(filter).FirstOrDefault();
        }

        public void Save(DataCollector dataCollector)
        {
            var filter = Builders<DataCollector>.Filter.Eq(c => c.Id, dataCollector.Id);
            _collection.ReplaceOne(filter, dataCollector, new UpdateOptions { IsUpsert = true });
        }
    }
}