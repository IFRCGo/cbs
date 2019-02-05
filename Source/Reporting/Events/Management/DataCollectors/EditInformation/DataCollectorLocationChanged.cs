/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.Management.DataCollectors.EditInformation
{
    public class DataCollectorLocationChanged : IEvent
    {
        public double LocationLatitude { get; }
        public double LocationLongitude { get; }

        public DataCollectorLocationChanged(double locationLatitude, double locationLongitude)
        {
            LocationLatitude = locationLatitude;
            LocationLongitude = locationLongitude;
        }
    }
}