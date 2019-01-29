/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

// TODO: CANNOT FIND THIS EVENT IN ANY BOUNDED CONTEXT
using Dolittle.Events;
using System;

namespace Events.Admin.Reporting.DefaultReplyMessages
{
    public class DefaultAutomaticReplyDefined : IEvent
    {
        public Guid Id { get; }
        public int Type { get; }
        public string Language { get; }
        public string Message { get; }

        public DefaultAutomaticReplyDefined(Guid id, int type, string language, string message) 
        {
            Id = id;
            Type = type;
            Language = language;
            Message = message;               
        }
    }
}
