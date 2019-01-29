/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.Management.DataCollectors.EditInformation
{
    public class DataCollectorUserInformationChanged : IEvent
    {
        public string FullName { get; }
        public string DisplayName { get; }

        public int YearOfBirth { get; }
        public int Sex { get; }

        public string Region { get; }
        public string District { get; }

        public DataCollectorUserInformationChanged(string fullName, string displayName, int yearOfBirth, int sex, string region, string district)
        {
            FullName = fullName;
            DisplayName = displayName;
            YearOfBirth = yearOfBirth;
            Sex = sex;
            Region = region;
            District = district;
        }
    }
}