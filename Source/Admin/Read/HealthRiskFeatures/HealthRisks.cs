/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Read.HealthRiskFeatures
{
    public class HealthRisks : IHealthRisks
    {
        private IMongoDatabase _database;
        private IMongoCollection<HealthRisk> _collection;

        public HealthRisks(IMongoDatabase database)

        {
            _database = database;
            _collection = database.GetCollection<HealthRisk>("HealthRisk");
        }

        public IEnumerable<HealthRisk> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        public HealthRisk GetById(Guid id)
        {
            return _collection.Find(v => v.Id == id).Single();
        }

        public async Task<IEnumerable<HealthRisk>> GetAllAsync()
        {
            var filter = Builders<HealthRisk>.Filter.Empty;
            var list = await _collection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public void Save(HealthRisk healthRisk)
        {
            _collection.InsertOne(healthRisk);
        }
    }
}