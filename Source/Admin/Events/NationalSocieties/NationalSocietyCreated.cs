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
        
        public NationalSocietyCreated (string name, string country, Guid id, int timezoneOffsetFromUtcInMinutes) 
        {
            this.Name = name;
            this.Country = country;
            this.Id = id;
            this.TimezoneOffsetFromUtcInMinutes = timezoneOffsetFromUtcInMinutes;

        }
        public string Name { get; }
        public string Country { get; }
        public Guid Id { get; }
        public int TimezoneOffsetFromUtcInMinutes { get; }
    }
}