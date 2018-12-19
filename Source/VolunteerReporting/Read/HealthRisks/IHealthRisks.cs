/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using MongoDB.Driver;
using Concepts.HealthRisk;

namespace Read.HealthRisks
{
    public interface IHealthRisks : IExtendedReadModelRepositoryFor<HealthRisk>
    {
        IEnumerable<HealthRisk> GetAll();

        HealthRisk GetById(HealthRiskId id);

        HealthRisk GetByReadableId(HealthRiskReadableId readableId);

        HealthRiskId GetIdFromReadableId(HealthRiskReadableId readableId);
        void SaveHealthRisk(HealthRiskId id, HealthRiskReadableId readableId, string name);
        UpdateResult UpdateHealthRisk(HealthRiskId id, HealthRiskReadableId readableId, string name);
    }
}
