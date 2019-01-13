/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.DataCollectors.Registration
{
    public class DataCollectorRegistered : IEvent
    {
        public Guid DataCollectorId { get; }
        public string FullName { get; }
        public string DisplayName { get; }
        public int YearOfBirth { get; }
        public int Sex { get;}
        public int PreferredLanguage { get; }
        public double LocationLongitude { get; }
        public double LocationLatitude { get; }

        public string Region { get; }
        public string District { get; }
        public DateTimeOffset RegisteredAt { get; }

        
        public DataCollectorRegistered(
            Guid dataCollectorId,
            string fullName,
            string displayName,            
            int yearOfBirth,
            int sex,
            int preferredLanguage,
            double locationLongitude, 
            double locationLatitude,
            DateTimeOffset registeredAt,
            string region,
            string district)
        {
            DataCollectorId = dataCollectorId;
            FullName = fullName;
            DisplayName = displayName;
            YearOfBirth = yearOfBirth;
            Sex = sex;
            PreferredLanguage = preferredLanguage;
            LocationLongitude = locationLongitude;
            LocationLatitude = locationLatitude;
            RegisteredAt = registeredAt;
            Region = region;
            District = district;
        }
    }
}