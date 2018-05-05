/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Read.HealthRiskFeatures
{
    public interface IHealthRisks
    {
        void Save(HealthRisk healthRisk);
        Task SaveAsync(HealthRisk healthRisk);

        IEnumerable<HealthRisk> GetAll();
        Task<IEnumerable<HealthRisk>> GetAllAsync();

        HealthRisk GetById(Guid id);

        Task RemoveAsync(Guid id);

        Task ReplaceAsync(HealthRisk healthRisk);

        UpdateResult Update(FilterDefinition<HealthRisk> filter, UpdateDefinition<HealthRisk> update);
        UpdateResult Update(Expression<Func<HealthRisk, bool>> filter, UpdateDefinition<HealthRisk> update);
    }
}