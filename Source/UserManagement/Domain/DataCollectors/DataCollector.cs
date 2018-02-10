/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using doLittle.Domain;
using Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DataCollectors
{
    //TODO: Implement domain object after references have been fixed. Right now, "doLittle.Runtime.Events" Version="2.0.0-alpha2.70" in 
    //Events projects refer to another IEvent then what Apply needs and if we change to doLittle in Events, then all events must implement EventSourceId which also seems strange
    public class DataCollector : AggregateRoot
    {
        public DataCollector(Guid id) : base(id) { }

        //TODO: Add method to apply data collector added events
        //TODO: RegisteredAt should be set in the apply method
            //public void AddDataCollector(
        
        //    )

        //TODO: Add business validation that checks if number is already added
        public void AddPhoneNumber(string phoneNumber)
        {
            Apply(new PhoneNumberAddedToDataCollector
            {
                Id = Guid.NewGuid(),
                DataCollectorId = EventSourceId,
                PhoneNumber = phoneNumber
            });
        }

        public void RemovePhoneNumber(string phoneNumber)
        {
            Apply(new PhoneNumberRemovedFromDataCollector
            {
                Id = Guid.NewGuid(),
                DataCollectorId = EventSourceId,
                PhoneNumber = phoneNumber
            });
        }
    }
}
