/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Events;
using System;

namespace Events.Reporting.AutomaticReplyMessages
{
    public class AutomaticReplyKeyMessageDefined : IEvent
    {
        public Guid Id { get; }
        public Guid ProjectId { get; }
        public Guid HealthRiskId { get; }
        public int Type { get; }
        public string Language { get; }
        public string Message { get; }

        public AutomaticReplyKeyMessageDefined(Guid id, Guid projectId, Guid healthRiskId, int type, string language, string message) 
        {
            Id = id;
            ProjectId = projectId;
            HealthRiskId = healthRiskId;
            Type = type;
            Language = language;
            Message = message;               
        }
    }
}
