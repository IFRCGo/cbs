/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.Admin.Reporting.HealthRisks
{
    [Artifact("52a974ab-383c-4750-b788-528f43b7ebf8")]
    public class HealthRiskDeleted : IEvent
    {
        public Guid HealthRiskId { get; }

        public HealthRiskDeleted(Guid healthRiskId) 
        {
            HealthRiskId = healthRiskId;               
        }
    }
}