/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.Reporting.AutomaticReplyMessages
{
    public class AutomaticReplyRemoved : IEvent
    {
        public Guid Id { get; }

        public AutomaticReplyRemoved(Guid id)
        {
            Id = id;
        }
    }
}
