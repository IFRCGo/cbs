using System;
using Dolittle.Concepts;

namespace Concepts
{
    /// <summary>
    /// Represents a specific day in terms of the number of days since Unix Epoch
    /// </summary>
    public class Day : ConceptAs<int>
    {
        public static implicit operator Day(int value)
        {
            return new Day {Value = value};
        }

        public static Day For(DateTimeOffset timestamp)
        {
            return new Day {
                Value = (int)Math.Floor((timestamp - DateTimeOffset.FromUnixTimeSeconds(0)).TotalDays)
            };
        }
    }
}
