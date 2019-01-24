/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Events;
using System;

namespace Events.Management.DataCollectors.EditInformation
{
    public class PhoneNumberAddedToDataCollector : IEvent
    {
        public string PhoneNumber { get; }

        public PhoneNumberAddedToDataCollector(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
