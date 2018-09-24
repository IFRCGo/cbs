/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Artifacts;
using Dolittle.Events;
using System;

namespace Events.External
{
    [Artifact("f04ec357-cac5-468f-9fab-9e822be1360e")]
    public class PhoneNumberAddedToDataCollector : IEvent
    {        
        public PhoneNumberAddedToDataCollector(Guid dataCollectorId, string phoneNumber) 
        {
            this.DataCollectorId = dataCollectorId;
            this.PhoneNumber = phoneNumber;
               
        }
                public Guid DataCollectorId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
