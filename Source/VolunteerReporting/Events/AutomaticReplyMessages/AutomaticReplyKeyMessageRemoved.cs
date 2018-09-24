/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;
namespace Events.AutomaticReplyMessages
{
    public class AutomaticReplyKeyMessageRemoved : IEvent
    {
        public AutomaticReplyKeyMessageRemoved(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
