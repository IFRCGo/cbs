/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.Projects
{
    public class ProjectDeleted : IEvent 
    {
        
        public ProjectDeleted (Guid projectId) 
        {
            ProjectId = projectId;

        }
        public Guid ProjectId { get; }
    }
}