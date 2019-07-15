using Dolittle.Concepts;

namespace Concepts
{
    public class NumberOfPeople : ConceptAs<int>
    {
        public static implicit operator NumberOfPeople(int value)
        {
            return new NumberOfPeople {Value = value};
        }
    }
}