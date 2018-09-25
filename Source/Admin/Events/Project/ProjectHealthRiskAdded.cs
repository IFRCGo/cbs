/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.Project
{
    public class ProjectHealthRiskAdded : IEvent
    {
        public ProjectHealthRiskAdded(Guid projectId, Guid healthRiskId, int threshold) 
        {
            this.ProjectId = projectId;
            this.HealthRiskId = healthRiskId;
            this.Threshold = threshold;
               
        }
        public Guid ProjectId { get; }
        public Guid HealthRiskId { get; }
        public int Threshold { get; }
    }
}