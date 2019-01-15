/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Events;
using System;

namespace Events.DataCollectors.PhoneNumber
{
    public class PhoneNumberAddedToDataCollector : IEvent
    {
        public Guid DataCollectorId { get; }
        public string PhoneNumber { get; }

        public PhoneNumberAddedToDataCollector(Guid dataCollectorId, string phoneNumber)
        {
            DataCollectorId = dataCollectorId;
            PhoneNumber = phoneNumber;
        }
    }
}
