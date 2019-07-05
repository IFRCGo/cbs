/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Events;

namespace Events.Reporting.DataCollectors
{
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
            this.FullName = fullName;
            this.DisplayName = displayName;
            this.YearOfBirth = yearOfBirth;
            this.Sex = sex;
            this.PreferredLanguage = preferredLanguage;
            this.LocationLongitude = locationLongitude;
            this.LocationLatitude = locationLatitude;
            this.RegisteredAt = registeredAt;
            this.Region = region;
            this.District = district;
            this.DataVerifierId = dataVerifierId;
        }
    
        public string FullName { get; }
        public string DisplayName { get; }
        public int YearOfBirth { get; }
        public int Sex { get;}
        public int PreferredLanguage { get; }
        public double LocationLongitude { get; }
        public double LocationLatitude { get; }
        public string Region { get; }
        public string District { get; }
        public Guid DataVerifierId {get; } 
        public DateTimeOffset RegisteredAt { get; }
    }
}