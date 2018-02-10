/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using doLittle.Events;
using System;

namespace Events.External
{
    class DefaultAutomaticReplyKeyMessageDeleted : IEvent
    {
        public Guid Id { get; set; }
    }
}
