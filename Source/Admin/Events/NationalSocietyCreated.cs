/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
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
    }
}