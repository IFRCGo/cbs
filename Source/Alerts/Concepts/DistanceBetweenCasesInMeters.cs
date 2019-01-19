using Dolittle.Concepts;

namespace Concepts
{
    public class DistanceBetweenCasesInMeters : ConceptAs<int>
    {
        public static implicit operator DistanceBetweenCasesInMeters(int value)
        {
            return new DistanceBetweenCasesInMeters { Value = value };
        }
    }
}