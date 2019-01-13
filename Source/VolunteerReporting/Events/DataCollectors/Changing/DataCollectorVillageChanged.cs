/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.DataCollectors.Changing
{
    public class DataCollectorVillageChanged : IEvent
    {
        public Guid DataCollectorId { get; }
        public string Village { get; }

        public DataCollectorVillageChanged(Guid dataCollectorId, string village) 
        {
            DataCollectorId = dataCollectorId;
            Village = village;               
        }        
    }
}