/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using doLittle.Events;

namespace Events
{
    public class ReplyMessageCreated : IEvent
    {
        public string Message { get; set; }
        public AutomaticReplyType ReplyType { get; set; }
    }
}