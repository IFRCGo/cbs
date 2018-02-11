/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Read.HealthRiskFeatures
{
    public interface IHealthRisks
    {
        void Save(HealthRisk project);

        IEnumerable<HealthRisk> GetAll();

        Task<IEnumerable<HealthRisk>> GetAllAsync();

        HealthRisk GetById(Guid id);
    }
}