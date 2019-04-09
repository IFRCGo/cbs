/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.Admin.Reporting.HealthRisks
{
    [Artifact("51b2c376-ce2b-4d49-a86c-e654e50248c9")]
    public class HealthRiskCreated : IEvent
    {
        public Guid Id { get; }
        public string Name { get; }
        public string CaseDefinition { get; }
        public int HealthRiskNumber { get; }

        public HealthRiskCreated (Guid id, string name, string caseDefinition, int healthRiskNumber) 
        {
            Id = id;
            Name = name;
            CaseDefinition = caseDefinition;
            HealthRiskNumber = healthRiskNumber;
        }
    }
}