/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.Management.MessageGenerators
{
    public class MessageGenerated : IEvent
    {
        public Guid DataCollectorId { get; }
        public string PhoneNumber { get; }
        public string Message { get; }

        public MessageGenerated(Guid dataCollectorId, string phoneNumber, string message) 
        {
            DataCollectorId = dataCollectorId;
            PhoneNumber = phoneNumber;
            Message = message;               
        }        
    }
}
