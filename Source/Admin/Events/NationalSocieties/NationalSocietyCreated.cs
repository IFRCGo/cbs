/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.NationalSocieties
{
    public class NationalSocietyCreated : IEvent 
    {
        public string Name { get; }
        public string Country { get; }
        public Guid Id { get; }
        public int TimezoneOffsetFromUtcInMinutes { get; }

        public NationalSocietyCreated (Guid id, string name, string country, int timezoneOffsetFromUtcInMinutes) 
        {
            Id = id;
            Name = name;
            Country = country;
            TimezoneOffsetFromUtcInMinutes = timezoneOffsetFromUtcInMinutes;
        }
    }
}