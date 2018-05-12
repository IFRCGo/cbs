/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Infrastructure.Read;
using MongoDB.Driver;

namespace Read.HealthRiskFeatures
{
    public class HealthRisks : ExtendedReadModelRepositoryFor<HealthRisk>, 
        IHealthRisks
    {
        public HealthRisks(IMongoDatabase database)
            : base(database, database.GetCollection<HealthRisk>("HealthRisk"))

        {
        }

        public IEnumerable<HealthRisk> GetAll()
        {
            return GetMany(_ => true);
        }

        public HealthRisk GetById(Guid id)
        {
            return GetOne(v => v.Id == id);
        }

        public Task<IEnumerable<HealthRisk>> GetAllAsync()
        {
            return GetManyAsync(_ => true);
        }
    }
}