/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Infrastructure.Read;

namespace Read.ProjectFeatures
{
    public interface IProjectHealthRiskVersions : IExtendedReadModelRepositoryFor<ProjectHealthRiskVersion>
    {
        void Append(Guid projectId, ProjectHealthRisk healthRisk, DateTimeOffset effectiveFromTime);
        IEnumerable<ProjectHealthRiskVersion> GetByProjectIdAndHealthRiskId(Guid projectId, Guid healthRiskId);
    }
}