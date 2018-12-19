/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Events;
using System;

namespace Events.DataCollectors.Registration
{
    public class DataCollectorRemoved : IEvent
    {
        public Guid DataCollectorId { get;}

        public DataCollectorRemoved(Guid dataCollectorId)
        {
            DataCollectorId = dataCollectorId;
        }
    }
}