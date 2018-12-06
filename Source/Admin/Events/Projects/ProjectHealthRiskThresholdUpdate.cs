/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Events;

namespace Events.Projects
{
    public class ProjectHealthRiskThresholdUpdate : IEvent
    {
        public Guid ProjectId { get; }
        public Guid HealthRiskId { get; }
        public int Threshold { get; }

        public ProjectHealthRiskThresholdUpdate(Guid projectId, Guid healthRiskId, int threshold) 
        {
            ProjectId = projectId;
            HealthRiskId = healthRiskId;
            Threshold = threshold;               
        }
    }
}