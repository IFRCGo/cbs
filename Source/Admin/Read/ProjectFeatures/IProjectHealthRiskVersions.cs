/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;

namespace Read.ProjectFeatures
{
    public interface IProjectHealthRiskVersions
    {
        void Append(Guid projectId, ProjectHealthRisk healthRisk, DateTimeOffset effectiveFromTime);
        IEnumerable<ProjectHealthRiskVersion> GetByProjectIdAndHealthRiskId(Guid projectId, Guid healthRiskId);
    }
}