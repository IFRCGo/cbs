/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.HealthRisks
{
    public class HealthRiskModified : IEvent 
    {
        public Guid Id { get; }
        public string Name { get; }
        public string CaseDefinition { get; }
        public int HealthRiskNumber { get; }


        public HealthRiskModified (Guid id, string name, string caseDefinition, int healthRiskNumber) 
        {
            Id = id;
            Name = name;
            CaseDefinition = caseDefinition;
            HealthRiskNumber = healthRiskNumber;
        }
    }
}