/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.HealthRisks
{
    public class ThresholdAddedToHealthRIsk : IEvent
    {
        public Guid HealthRiskId { get; }
        public int Threshold { get; }

        public ThresholdAddedToHealthRIsk(Guid healthRiskId, int threshold)
        {
            HealthRiskId = healthRiskId;
            Threshold = threshold;
        }
    }
}