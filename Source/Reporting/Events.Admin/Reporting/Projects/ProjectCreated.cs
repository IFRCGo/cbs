/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Artifacts;
using Dolittle.Events;
using System;

namespace Events.Admin.Reporting.Projects
{
    [Artifact("8c120f9a-1f56-43b4-a12a-2bfa5699bc21")]
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