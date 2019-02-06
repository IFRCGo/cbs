/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Concepts;

namespace Concepts.DataCollectors
{
    public class Location : Value<Location>
    {
        public static readonly Location NotSet = new Location(double.MinValue, double.MinValue);
        
        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
         }

        public double Latitude { get; }
        public double Longitude { get; }

        public override string ToString() => Latitude.ToString("##.###") + ", " + Longitude.ToString("##.###");


        public bool IsValid()
        {
            return (Latitude >= -90 && Latitude <= 90) && (Longitude >= -180 && Longitude <= 180);
        }
    }
}
