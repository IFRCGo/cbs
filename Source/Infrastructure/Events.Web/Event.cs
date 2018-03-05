/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;

namespace Infrastructure.Events.Web
{
    public class Event
    {
        public string Name { get; set; }
        public Guid EventSourceId { get; set; }
        public dynamic Content { get; set; }
    }
}