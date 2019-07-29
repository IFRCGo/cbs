using Dolittle.Concepts;

namespace Concepts
{
    public class NumberOfCasereports : ConceptAs<int>
    {
        public static implicit operator NumberOfCasereports(int value)
        {
            return new NumberOfCasereports {Value = value};
        }
    }
}
