/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using Dolittle.Events;

namespace Events.ReplyMessage
{
    public class ReplyMessageConfigUpdated : IEvent
    {
        public IDictionary<string,IDictionary<string,string>> Messages { get; set; }
    }
}