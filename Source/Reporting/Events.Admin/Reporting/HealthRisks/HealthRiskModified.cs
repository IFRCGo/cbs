/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.Admin.Reporting.HealthRisks
{
    [Artifact("ab9f13e6-f68b-4683-96fe-13434fd34516")]
    public class HealthRiskModified : IEvent
    {
        public Guid Id { get; }
        public string Name { get; }
        public int ReadableId { get; }

        public HealthRiskModified(Guid id, string name, int readableId) 
        {
            Id = id;
            Name = name;
            ReadableId = readableId;               
        }
    }
}