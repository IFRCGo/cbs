/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.HealthRisks
{
    public class KeyMessageAddedToHealthRisk : IEvent
    {
        public KeyMessageAddedToHealthRisk(Guid healthRiskId, Guid keyMessageId, string message, string language)
        {
            HealthRiskId = healthRiskId;
            KeyMessageId = keyMessageId;
            Message = message;
            Language = language;
        }

        public Guid HealthRiskId { get; }
        public Guid KeyMessageId { get; }
        public string Message { get; }
        public string Language { get; }
    }
}