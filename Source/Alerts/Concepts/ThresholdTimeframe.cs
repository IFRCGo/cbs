using System;
using Dolittle.Concepts;

namespace Concepts
{
    public class ThresholdTimeframe : ConceptAs<TimeSpan>
    {
        public static implicit operator ThresholdTimeframe(TimeSpan value)
        {
            return new ThresholdTimeframe { Value = value };
        }
    }
}