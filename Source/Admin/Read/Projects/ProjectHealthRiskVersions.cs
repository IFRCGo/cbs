/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Infrastructure.Read.MongoDb;
using MongoDB.Driver;

namespace Read.Projects
{
    public class ProjectHealthRiskVersions :ExtendedReadModelRepositoryFor<ProjectHealthRiskVersion>, 
        IProjectHealthRiskVersions
    {

        public ProjectHealthRiskVersions(IMongoDatabase database)
            : base(database, database.GetCollection<ProjectHealthRiskVersion>("ProjectHealthRiskVersion"))
        {
        }

        public void Append(Guid projectId, ProjectHealthRisk healthRisk, DateTimeOffset effectiveFromTime)
        {
            Insert(new ProjectHealthRiskVersion
            {
                Id = Guid.NewGuid(),
                EffectiveFromTime = effectiveFromTime,
                HealthRisk = healthRisk,
                ProjectId = projectId
            });
        }

        public IEnumerable<ProjectHealthRiskVersion> GetByProjectIdAndHealthRiskId(Guid projectId, Guid healthRiskId)
        {
            return GetMany(p => p.ProjectId == projectId && p.HealthRisk.HealthRiskId == healthRiskId);
        }
    }
}