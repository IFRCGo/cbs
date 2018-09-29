/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.Events;

namespace Events.AutomaticReplyMessages
{
    public class ReplyMessageConfigUpdated : IEvent
    {
        // Comment: This is a really bad event.
        //TODO: This event will actually now work, Events cannot currently have dictionaries in it
        public ReplyMessageConfigUpdated(IDictionary<string, IDictionary<string, string>> messages)
        {
            Messages = messages;
        }
        public IDictionary<string,IDictionary<string,string>> Messages { get; }
    }
}