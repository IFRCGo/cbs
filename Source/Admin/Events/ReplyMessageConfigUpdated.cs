/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using doLittle.Events;

namespace Events
{
    public class ReplyMessageConfigUpdated : IEvent
    {
        public IDictionary<string,IDictionary<string,string>> Messages { get; set; }
    }
}