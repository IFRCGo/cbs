/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Concepts;

namespace Concepts
{
    /// <summary>
    /// Represents a specific date as number of days since Unix Epoch.
    /// </summary>
    public class Day : ConceptAs<int>
    {
        public static implicit operator Day(int value)
        {
            return new Day {Value = value};
        }

        public static Day From(DateTimeOffset timestamp)
        {
            var daysSinceEpoch = (timestamp - DateTimeOffset.FromUnixTimeSeconds(0)).TotalDays;
            return new Day {
                Value = (int)Math.Floor(daysSinceEpoch)
            };
        }

        public static Day Today
        {
            get => Day.From(DateTimeOffset.Now);
        }
    }
}
