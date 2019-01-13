/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.DataCollector
{
    public class DataCollectorBeganTraining : IEvent
    {
        public Guid DataCollectorId { get;  }

        public DataCollectorBeganTraining(Guid dataCollectorId)
        {
            DataCollectorId = dataCollectorId;
        }
    }
}
