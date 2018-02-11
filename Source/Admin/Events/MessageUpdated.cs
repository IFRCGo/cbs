/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using doLittle.Events;

namespace Events
{
    public class MessageUpdated : IEvent
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}