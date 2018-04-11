/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.HealthRiskFeatures
{
    public interface IHealthRisks
    {
        Task SaveAsync(HealthRisk healthRisk);

        IEnumerable<HealthRisk> GetAll();

        Task<IEnumerable<HealthRisk>> GetAllAsync();

        HealthRisk GetById(Guid id);

        Task RemoveAsync(Guid id);

        Task ReplaceAsync(HealthRisk healthRisk);
    }
}