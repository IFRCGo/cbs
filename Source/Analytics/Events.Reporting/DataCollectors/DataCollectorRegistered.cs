/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.Reporting.DataCollectors
{
    [Artifact("899f24ac-860d-4dae-ae90-938ac12e5226", 1)]
    public class DataCollectorRegistered : IEvent
    {
        public DataCollectorRegistered (
                string fullName,
                string displayName,            
                int yearOfBirth,
                int sex,
                int preferredLanguage,
                double locationLongitude, 
                double locationLatitude,
                DateTimeOffset registeredAt,
                string region,
                string district,
                Guid dataVerifierId
            )
        {
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
            DataVerifierId = dataVerifierId;
        }
    
        public string FullName { get; }
        public string DisplayName { get; }
        public int YearOfBirth { get; }
        public int Sex { get; }
        public int PreferredLanguage { get; }
        public double LocationLongitude { get; }
        public double LocationLatitude { get; }
        public string Region { get; }
        public string District { get; }
        public Guid DataVerifierId { get; } 
        public DateTimeOffset RegisteredAt { get; }
    }
}