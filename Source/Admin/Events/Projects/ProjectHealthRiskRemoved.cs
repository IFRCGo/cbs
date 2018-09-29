/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Events;

namespace Events.Projects
{
    public class ProjectHealthRiskRemoved : IEvent
    {
        
        public ProjectHealthRiskRemoved(Guid projectId, Guid healthRiskId) 
        {
            this.ProjectId = projectId;
            this.HealthRiskId = healthRiskId;
        }
        public Guid ProjectId { get; }
        public Guid HealthRiskId { get; }
    }
}