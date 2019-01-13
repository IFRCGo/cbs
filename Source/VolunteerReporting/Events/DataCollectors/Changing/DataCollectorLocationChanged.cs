/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.DataCollectors.Changing
{
    public class DataCollectorLocationChanged : IEvent
    {
        public Guid DataCollectorId { get; }
        public double LocationLatitude { get; }
        public double LocationLongitude { get; }

        public DataCollectorLocationChanged(Guid dataCollectorId, double locationLatitude, double locationLongitude)
        {
            DataCollectorId = dataCollectorId;
            LocationLatitude = locationLatitude;
            LocationLongitude = locationLongitude;
        }
    }
}