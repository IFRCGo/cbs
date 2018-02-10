/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;

namespace Domain
{
    public interface IProjectHealthRiskRules
    {
        bool IsWithinNumberOfHealthRisksLimit(Guid project);


        bool IsHealthRiskUniqueWithinProject(Guid healthRiskId, Guid projectId);

        bool IsHealthRiskExisting(Guid healthRiskId);
    }
}