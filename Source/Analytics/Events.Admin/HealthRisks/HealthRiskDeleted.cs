/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.Admin.HealthRisks
{
    [Artifact("787d61d1-79bb-473a-9329-171478eff750", 1)]
    public class HealthRiskDeleted : IEvent
    {
        public Guid HealthRiskId { get; }

        public HealthRiskDeleted(Guid healthRiskId)
        {
            HealthRiskId = healthRiskId;
        }
    }
}