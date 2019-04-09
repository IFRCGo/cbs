/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Artifacts;
using Dolittle.Events;
using System;

namespace Events.Admin.Reporting.Projects
{
    [Artifact("f8841be6-6da1-4571-b737-f72b283b3760")]
    public class ProjectCreated : IEvent
    {
        public Guid Id { get; }
        public string Name { get; }

        public ProjectCreated(Guid id, string name) 
        {
            Id = id;
            Name = name;               
        }
    }
}