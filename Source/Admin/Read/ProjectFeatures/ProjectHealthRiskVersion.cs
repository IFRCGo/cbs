/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;

namespace Read.ProjectFeatures
{
    public class ProjectHealthRiskVersion
    {
        public Guid Id { get; set; } // Do we really need this?
        public Guid ProjectId { get; set; }
        public ProjectHealthRisk HealthRisk { get; set; }
        public DateTimeOffset EffectiveFromTime { get; set; }
    }
}