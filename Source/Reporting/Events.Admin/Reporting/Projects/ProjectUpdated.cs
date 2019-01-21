/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Artifacts;
using Dolittle.Events;
using System;

namespace Events.Admin.Reporting.Projects
{
    [Artifact("753c49a2-8b97-4823-8e76-c5fe80a432db")]
    public class ProjectUpdated : IEvent
    {
        public Guid Id { get; }
        public string Name { get; }

        public ProjectUpdated(Guid id, string name) 
        {
            Id = id;
            Name = name;               
        }
    }
}