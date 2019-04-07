/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Artifacts;
using Dolittle.Events;
using System;

namespace Events.Admin.Reporting.Projects
{
    [Artifact("60b0104a-9ec8-4447-9dd0-0867fcec1a35")]
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