/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Artifacts;
using Dolittle.Events;
using System;

namespace Events.External
{
    [Artifact("0a4fa57d-082b-4229-a508-d13e20376d31")]
    public class PhoneNumberRemovedFromDataCollector : IEvent
    {
        public PhoneNumberRemovedFromDataCollector(Guid dataCollectorId, string phoneNumber) 
        {
            this.DataCollectorId = dataCollectorId;
            this.PhoneNumber = phoneNumber;
               
        }
        public Guid DataCollectorId { get; }
        public string PhoneNumber { get; }
    }
}
