/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.Admin.Reporting.HealthRisks
{
    [Artifact("8ba78d0d-1944-463e-bcad-11a037adf743")]
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