using Dolittle.Concepts;

namespace Concepts
{
    public class NumberOfCasesThreshold : ConceptAs<int>
    {
        public static implicit operator NumberOfCasesThreshold(int value)
        {
            return new NumberOfCasesThreshold { Value = value };
        }
    }
}