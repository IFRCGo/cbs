/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using doLittle.Events;

namespace Events
{
    public class NationalSocietyCreated : IEvent
    {
        public String Name { get; set; }
        public String Country { get; set; }
        public Guid Id { get; set; }
        public int TimezoneOffsetFromUtcInMinutes { get; set; }
    }
}