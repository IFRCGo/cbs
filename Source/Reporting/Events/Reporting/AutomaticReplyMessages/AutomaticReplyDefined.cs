/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Events;
using System;

namespace Events.Reporting.AutomaticReplyMessages
{
    public class AutomaticReplyDefined : IEvent
    {
        public Guid Id { get; }
        public Guid ProjectId { get; }
        public int Type { get; }
        public string Language { get; }
        public string Message { get; }

        public AutomaticReplyDefined(Guid id, Guid projectId, int type, string language, string message) 
        {
            Id = id;
            ProjectId = projectId;
            Type = type;
            Language = language;
            Message = message;               
        }
    }
}
